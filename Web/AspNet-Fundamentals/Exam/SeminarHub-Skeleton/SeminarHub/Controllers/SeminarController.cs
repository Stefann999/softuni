using Microsoft.AspNetCore.Mvc;
using SeminarHub.Core.Models;
using SeminarHub.Core.Services.Contracts;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    public class SeminarController : Controller
    {
        private readonly ISeminarService seminarService;

        public SeminarController(ISeminarService seminarService)
        {
            this.seminarService = seminarService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormModel();
            model.Categories = await seminarService.GetCategoryTypesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel model)
        {
            var allCategories = await seminarService.GetCategoryTypesAsync();

            model.Categories = allCategories;
            model.OrganizerId = GetUserId();

            if (!allCategories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            ModelState.Remove("OrganizerId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await seminarService.AddSeminarAsync(model);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
        {
            var seminars = await seminarService.GetAllSeminarsAsync();

            return View(seminars);
        }

        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var joinedEvents = await seminarService.GetAllJoinedSeminarsAsync(userId);

            return View(joinedEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await seminarService.GetCategoryTypesAsync();

            var seminarToEdit = await seminarService.GetSeminarByIdAsync(id);

            seminarToEdit.Categories = categories;

            var currentUserId = GetUserId();

            if (currentUserId != seminarToEdit.OrganizerId)
            {
                return Unauthorized();
            }

            return View(seminarToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarFormModel model)
        {
            var categories = await seminarService.GetCategoryTypesAsync();

            var currSeminar = await seminarService.GetSeminarByIdAsync(id);

            currSeminar.Categories = categories;
            model.Categories = categories;

            ModelState.Remove("OrganizerId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            currSeminar.Topic = model.Topic;
            currSeminar.Lecturer = model.Lecturer;
            currSeminar.Details = model.Details;
            currSeminar.DateAndTime = model.DateAndTime;
            currSeminar.Duration = model.Duration;
            currSeminar.CategoryId = model.CategoryId;

            try
            {
                await seminarService.EditSeminarAsync(id, currSeminar);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Join(int id)
        {
            var userId = GetUserId();

            var alreadyJoined = await seminarService.GetAllJoinedSeminarsAsync(userId);

            if (alreadyJoined.Any(x => x.Id == id))
            {
                return RedirectToAction(nameof(All));
            }

            try
            {
                await seminarService.AddSeminarToJoinedSeminarsAsync(userId, id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var userId = GetUserId();

            try
            {
                await seminarService.RemoveSeminarFromJoinedSeminarsAsync(userId, id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Details(int id)
        {
            var semianrDetails = await seminarService.GetSeminarDetailsByIdAsync(id);

            return View(semianrDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var semiarForDelete = await seminarService.GetSeminarForDeleteByIdAsync(id);

            if (semiarForDelete == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != semiarForDelete.OrganizerId)
            {
                return Unauthorized();
            }

            return View(semiarForDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel model)
        {
            var seminarForDelete = await seminarService.GetSeminarForDeleteByIdAsync(model.Id);

            if (seminarForDelete == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != seminarForDelete.OrganizerId)
            {
                return Unauthorized();
            }

            try
            {
                await seminarService.DeleteSeminarAsync(model.Id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
    }
}
