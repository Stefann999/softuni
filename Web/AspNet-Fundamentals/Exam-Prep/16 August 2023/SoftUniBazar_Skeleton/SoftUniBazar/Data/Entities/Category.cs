using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.EntityValidationsConstants.Category;

namespace SoftUniBazar.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
