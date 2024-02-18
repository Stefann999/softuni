using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Common.EntityValidationsConstants.Seminar;

namespace SeminarHub.Data.Entities
{
    [Comment("Seminars for the SeminarHub")]
    public class Seminar
    {
        public Seminar()
        {
            this.SeminarsParticipants = new HashSet<SeminarParticipant>();
        }

        [Comment("The Primary Key of the Seminar")]
        [Key]
        public int Id { get; set; }

        [Comment("The topic of the seminar")]
        [Required]
        [MaxLength(TopicMaxLength)]
        public string Topic { get; set; } = string.Empty;

        [Comment("The lecturer of the seminar")]
        [Required]
        [MaxLength(LecturerMaxLength)]
        public string Lecturer { get; set; } = string.Empty;

        [Comment("Details for the seminar")]
        [Required]
        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; } = string.Empty;

        [Comment("The seminar's organizer id")]
        [Required]
        [ForeignKey(nameof(Organizer))]
        public string OrganizerId { get; set; } = string.Empty;

        [Comment("The seminar's organizer")]
        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Comment("The seminar's start date and time")]
        [Required]
        [DisplayFormat(DataFormatString = DateTimeFormat)]
        public DateTime DateAndTime { get; set; }

        [Comment("The seminar's duration in minutes")]
        [Range(DurationMinValue, DurationMaxValue)]
        public int? Duration { get; set; }

        [Comment("The seminar's category id")]
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Comment("The seminar's category")]
        [Required]
        public Category Category { get; set; } = null!;

        [Comment("The seminar's participants")]
        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = null!;
    }
}
