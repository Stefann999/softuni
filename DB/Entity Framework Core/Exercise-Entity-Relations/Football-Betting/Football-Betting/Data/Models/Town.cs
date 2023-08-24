using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
        }
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name{ get; set; } = null!;

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
