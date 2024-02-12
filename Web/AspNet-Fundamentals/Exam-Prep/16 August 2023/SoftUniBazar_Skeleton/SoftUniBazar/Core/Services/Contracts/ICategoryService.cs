using SoftUniBazar.Core.Models;

namespace SoftUniBazar.Core.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllAsync();
    }
}
