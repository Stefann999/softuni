using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    using static Common.EntityValidationsConstants.Board;
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
