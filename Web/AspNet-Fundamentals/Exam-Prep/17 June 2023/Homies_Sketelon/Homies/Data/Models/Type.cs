using System.ComponentModel.DataAnnotations;
using static Homies.Constants.DataConstants;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Event> Events { get; set; } = null!;
    }
}
