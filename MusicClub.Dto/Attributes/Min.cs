using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Attributes
{
    public class Min(int min) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }


            if(value is not int page)
            {
                return new ValidationResult("The value should be an integer");
            }


            if(page < min)
            {
                return new ValidationResult($"The value should not be smaller than {min}");
            }


            return ValidationResult.Success;
        }
    }
}
