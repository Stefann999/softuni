using SoftUniBazar.Core.Models;

namespace SoftUniBazar.Core.Services.Contracts
{
    public interface IAdService
    {
        Task<IEnumerable<AdAllViewModel>> AllAsync();

        Task AddAsync(AdFormModel formModel, string ownerId);

        Task AddToCart(int id, string userId);
    }
}
