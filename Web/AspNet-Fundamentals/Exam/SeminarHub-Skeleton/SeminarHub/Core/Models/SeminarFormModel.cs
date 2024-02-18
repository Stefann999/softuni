using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.EntityValidationsConstants.Seminar;
using static SeminarHub.Common.ErrorConstants;

namespace SeminarHub.Core.Models
{
    public class SeminarFormModel
    {
        public SeminarFormModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TopicMaxLength,
                      MinimumLength = TopicMinLength,
                      ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = null!;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LecturerMaxLength,
                       MinimumLength = LecturerMinLength,
                       ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DetailsMaxLength,
                       MinimumLength = DetailsMinLength,
                       ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string DateAndTime { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(DurationMinValue, DurationMaxValue, ErrorMessage = RangeErrorMessage)]
        public int? Duration { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }

        [Required]
        public string OrganizerId { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
    }
}
