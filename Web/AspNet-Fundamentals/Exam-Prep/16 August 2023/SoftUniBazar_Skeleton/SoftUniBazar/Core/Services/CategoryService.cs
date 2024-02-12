using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Core.Models;
using SoftUniBazar.Core.Services.Contracts;
using SoftUniBazar.Data;

namespace SoftUniBazar.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext context;

        public CategoryService(BazarDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllAsync()
        {
            return await context.Categories
               .AsNoTracking()
               .Select(t => new CategoryViewModel
               {
                   Id = t.Id,
                   Name = t.Name
               })
               .ToListAsync();
        }
    }
}
