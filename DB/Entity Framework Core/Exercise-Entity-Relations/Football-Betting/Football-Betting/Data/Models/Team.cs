using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_Football_Betting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }


        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }
    }
}
