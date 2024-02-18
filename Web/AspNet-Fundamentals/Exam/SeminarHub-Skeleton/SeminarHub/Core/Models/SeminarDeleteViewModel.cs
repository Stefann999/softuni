namespace SeminarHub.Core.Models
{
    public class SeminarDeleteViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

        public string OrganizerId { get; set; } = null!;
    }
}
