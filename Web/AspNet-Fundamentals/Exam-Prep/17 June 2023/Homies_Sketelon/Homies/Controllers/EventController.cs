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




        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

    }
}
