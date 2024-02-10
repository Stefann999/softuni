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

        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

    }
}
