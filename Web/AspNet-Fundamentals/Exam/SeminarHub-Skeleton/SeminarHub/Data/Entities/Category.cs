using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.EntityValidationsConstants.Category;

namespace SeminarHub.Data.Entities
{
    [Comment("Categories of seminars")]
    public class Category
    {
        public Category()
        {
            this.Seminars = new HashSet<Seminar>();
        }

        [Comment("The Primary Key of the Category")]
        [Key]
        public int Id { get; set; }

        [Comment("The name of the Category")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("The Category's Seminars")]
        public ICollection<Seminar> Seminars { get; set; } = null!;
    }
}
