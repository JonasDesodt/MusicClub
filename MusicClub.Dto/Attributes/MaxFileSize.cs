using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Attributes
{
    public class MaxFileSize : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }

            if (value is IBrowserFile { Size: < 512000 })
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The size should be less than 512000 bytes");
        }
    }
}