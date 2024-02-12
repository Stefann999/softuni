using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Common;
using SoftUniBazar.Core.Models;
using SoftUniBazar.Core.Services.Contracts;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Entities;
using static SoftUniBazar.Common.EntityValidationsConstants;

namespace SoftUniBazar.Core.Services
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext context;

        public AdService(BazarDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdAllViewModel>> AllAsync()
        {
            if (!context.Ads.Any())
            {
                return new List<AdAllViewModel>();
            }

            var allAds = await context.Ads
                .AsNoTracking()
                .Select(a => new AdAllViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Owner = a.Owner.UserName,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn.ToString(EntityValidationsConstants.Ad.DateFormat),
                    Category = a.Category.Name
                })
                .ToListAsync();

            return allAds;
        }

        public async Task AddAsync(AdFormModel formModel, string ownerId)
        {
            var ad = new Data.Entities.Ad
            {
                Name = formModel.Name,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                CategoryId = formModel.CategoryId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            await context.Ads.AddAsync(ad);
            await context.SaveChangesAsync();
        }

        public async Task AddToCart(int id, string userId)
        {
            var newAdAndBuyer = new AdBuyer()
            {
                AdId = id,
                BuyerId = userId
            };

            await context.AdsBuyers.AddAsync(newAdAndBuyer);
            await context.SaveChangesAsync();
        }
    }
}
