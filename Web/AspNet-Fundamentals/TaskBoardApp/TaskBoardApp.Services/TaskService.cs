using TaskBoardApp.Data;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext dbContext;

        public TaskService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string ownerId, TaskFormModel model)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            await this.dbContext.Tasks.AddAsync(task);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
