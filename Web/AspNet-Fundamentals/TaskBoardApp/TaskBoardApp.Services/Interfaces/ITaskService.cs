using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task AddAsync(string ownerId, TaskFormModel model);

        Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id);
    }
}
