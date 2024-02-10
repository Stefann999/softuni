using Homies.Data;
using Homies.Data.Models;
using static Homies.Constants.DataConstants;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using Homies.Constants;
using System.Globalization;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;

        public EventController(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var events = await context.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName
                    ))
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var e = await context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            string userId = GetCurrentUserId();

            if (!e.EventsParticipants.Any(p => p.HelperId == userId))
            {
                e.EventsParticipants.Add(new EventParticipant
                {
                    EventId = e.Id,
                    HelperId = userId
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Joined()
        {
            var userId = GetCurrentUserId();

            var events = await context.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.EventId,
                    e.Event.Name,
                    e.Event.Start,
                    e.Event.Type.Name,
                    e.Event.Organiser.UserName
                    ))
                .ToListAsync();

            return View(events);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var e = await context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (e == null)
            {
                return BadRequest();
            }

            var userId = GetCurrentUserId();

            var ep = e.EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            e.EventsParticipants.Remove(ep);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }

            var e = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Start = start,
                End = end,
                TypeId = model.TypeId,
                OrganiserId = GetCurrentUserId(),
                CreatedOn = DateTime.UtcNow
            };

            await context.Events.AddAsync(e);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await context.Events
                .FirstAsync(e => e.Id == id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetCurrentUserId())
            {
                return Unauthorized();
            }

            var formModel = new EventFormViewModel
            {
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString(DataConstants.DateFormat),
                End = e.End.ToString(DataConstants.DateFormat),
                TypeId = e.TypeId,
                Types = await GetTypes()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var e = await context.Events
                .FirstAsync(e => e.Id == id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetCurrentUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }

            e.Start = start;
            e.End = end;
            e.Name = model.Name;
            e.Description = model.Description;
            e.TypeId = model.TypeId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    End = e.End.ToString(DataConstants.DateFormat),
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }
            
            return View(model);
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await context.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
