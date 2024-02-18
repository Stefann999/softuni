using SeminarHub.Core.Models;

namespace SeminarHub.Core.Services.Contracts
{
    public interface ISeminarService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoryTypesAsync();

        Task AddSeminarAsync(SeminarFormModel model);

        Task<IEnumerable<SeminarViewModel>> GetAllSeminarsAsync();

        Task<IEnumerable<SeminarViewModel>> GetAllJoinedSeminarsAsync(string userId);

        Task<SeminarFormModel> GetSeminarByIdAsync(int id);

        Task EditSeminarAsync(int id, SeminarFormModel model);

        Task AddSeminarToJoinedSeminarsAsync(string userId, int seminarId);

        Task RemoveSeminarFromJoinedSeminarsAsync(string userId, int seminarId);

        Task<SeminarDetailsViewModel> GetSeminarDetailsByIdAsync(int id);

        Task<SeminarDeleteViewModel> GetSeminarForDeleteByIdAsync(int id);

        Task DeleteSeminarAsync(int id);
    }
}
