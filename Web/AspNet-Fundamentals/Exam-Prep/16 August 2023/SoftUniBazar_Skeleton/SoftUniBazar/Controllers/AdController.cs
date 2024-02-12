using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Common;
using SoftUniBazar.Core.Models;
using SoftUniBazar.Core.Services.Contracts;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Entities;
using System.Security.Claims;
using static SoftUniBazar.Common.EntityValidationsConstants;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;
        private readonly BazarDbContext context;
        
        public AdController(IAdService adService, ICategoryService categoryService, BazarDbContext context)
        {
            this.adService = adService;
            this.categoryService = categoryService;
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var allAds = await adService.AllAsync();

            return View(allAds);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormModel();
            model.Categories = await categoryService.AllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel formModel)
        {
            var allCategories = await categoryService.AllAsync();

            if (!allCategories.Any(c => c.Id == formModel.CategoryId))
            {
                ModelState.AddModelError(nameof(formModel.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await categoryService.AllAsync();
                return View(formModel);
            }
            
            var currentUserId = GetUserId();

            await adService.AddAsync(formModel, currentUserId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await this.context.Ads.FirstOrDefaultAsync(a => a.Id == id);

            if (ad == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != ad.OwnerId)
            {
                return Unauthorized();
            }

            AdFormModel adFormModel = new AdFormModel()
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                Categories = await categoryService.AllAsync()
            };

            return View(adFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormModel adFormModel, int id)
        {
            var ad = await this.context.Ads.FirstOrDefaultAsync(a => a.Id == id);

            if (ad == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != ad.OwnerId)
            {
                return Unauthorized();
            }

            var allCategories = await categoryService.AllAsync();

            if (!allCategories.Any(b => b.Id == adFormModel.CategoryId))
            {
                ModelState.AddModelError(nameof(adFormModel.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                adFormModel.Categories = allCategories;

                return View(adFormModel);
            }

            ad.Name = adFormModel.Name;
            ad.Description = adFormModel.Description;
            ad.ImageUrl = adFormModel.ImageUrl;
            ad.Price = adFormModel.Price;
            ad.CategoryId = adFormModel.CategoryId;

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var currentUserCart = await this.context.AdsBuyers
                .Where(ab => ab.BuyerId== GetUserId())
                .Select(ab => new CartViewModel
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn.ToString(EntityValidationsConstants.Ad.DateFormat),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName
                })
                .ToListAsync();

            return View(currentUserCart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = GetUserId();
            var adAndBuyer = await context.AdsBuyers.FirstOrDefaultAsync(ab => ab.AdId == id && ab.BuyerId == userId);

            if (adAndBuyer == null)
            {
               await this.adService.AddToCart(id, userId);
            }
            else
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();
            var adAndBuyer = await context.AdsBuyers.FirstOrDefaultAsync(ab => ab.AdId == id && ab.BuyerId == userId);

            if (adAndBuyer != null)
            {
                context.AdsBuyers.Remove(adAndBuyer);
                await context.SaveChangesAsync();
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
