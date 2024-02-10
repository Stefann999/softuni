using System.ComponentModel.DataAnnotations;
using static Homies.Constants.DataConstants;
using static Homies.Constants.ErrorConstants;

namespace Homies.Models
{
    public class EventFormViewModel
    {
        public EventFormViewModel()
        {
            this.Types = new HashSet<TypeViewModel>();
        }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventNameMaxLength,
                      MinimumLength = EventNameMinLength,
                      ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(EventDescriptionMaxLength,
                       MinimumLength = EventDescriptionMinLength,
                       ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = null!;
    }
}
