using Microsoft.AspNetCore.Identity;

namespace SeminarHub.Core.Models
{
    public class SeminarDetailsViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = null!;

        public string Lecturer { get; set; } = null!;

        public string Details { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

        public int Duration { get; set; }

        public string OrganizerId { get; set; } = null!;

        public IdentityUser Organizer { get; set; } = null!;

        public int CategoryId { get; set; }

        public string Category { get; set; } = null!;
    }
}
