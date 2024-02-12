using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.EntityValidationsConstants.Ad;
using static SoftUniBazar.Common.ErrorConstants;

namespace SoftUniBazar.Core.Models
{
    public class AdFormModel
    {
        public AdFormModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength,
                      MinimumLength = NameMinLength,
                      ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength,
                       MinimumLength = DescriptionMinLength,
                       ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        //[Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories{ get; set; } = null!;
    }
}
