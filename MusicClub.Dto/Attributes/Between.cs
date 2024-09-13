using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Attributes
{
    internal class Between(int min, int max) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }

            if (value is not int page)
            {
                return new ValidationResult("The value should be an integer");
            }

            if (page < min)
            {
                return new ValidationResult($"The value should not be smaller than {min}");
            }

            if(page > max)
            {
                return new ValidationResult($"The value should not be bigger than {max}");
            }

            return ValidationResult.Success;
        }
    }
}