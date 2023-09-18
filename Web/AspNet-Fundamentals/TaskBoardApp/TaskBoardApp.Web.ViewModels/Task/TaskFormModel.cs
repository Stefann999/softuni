using System.ComponentModel.DataAnnotations;
using Microsoft.Win32.SafeHandles;
using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Web.ViewModels.Task
{
    using static Common.EntityValidationsConstants.Task;
    public class TaskFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = "Title should be at least {2} characters long!")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "Title should be at least {2} characters long!")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardSelectViewModel>? Boards { get; set; }
    }
}
