using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Entities
{
    [Comment("The participants in the seminars")]
    public class SeminarParticipant
    {
        [Comment("The participant's seminar id")]
        [Required]
        [ForeignKey(nameof(Seminar))]
        public int SeminarId { get; set; }

        [Comment("The participants's seminar")]
        public Seminar Seminar { get; set; } = null!;

        [Comment("The seminar's participant id")]
        [Required]
        [ForeignKey(nameof(Participant))]
        public string ParticipantId { get; set; } = string.Empty;

        [Comment("The seminar's participant")]
        public IdentityUser Participant { get; set; } = null!;
    }
}
