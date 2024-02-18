using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.EntityValidationsConstants.Seminar;

namespace SeminarHub.Core.Models
{
    public class SeminarViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TopicMaxLength, MinimumLength = TopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public int  CategoryId { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;
    }
}
