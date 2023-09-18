using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel viewModel = new TaskFormModel()
            {
               Boards = await this.boardService.AllForSelectAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                return View(model);
            }

            bool boardExists = await this.boardService.ExistsByIdAsync(model.BoardId);

            if (!boardExists)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                model.Boards = await this.boardService.AllForSelectAsync();
                return View(model);
            }

            string currentUserId = this.User.GetId();

            await this.taskService.AddAsync(currentUserId, model);

            return this.RedirectToAction("All", "Board");
        }
    }
}
