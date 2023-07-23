using System.ComponentModel.DataAnnotations;
namespace ValidationAttributes.Attributes;

public class MyRequiredAttribute : MyValidationAttribute
{
    public override bool IsValid(object obj)
        => obj is not null;
}
