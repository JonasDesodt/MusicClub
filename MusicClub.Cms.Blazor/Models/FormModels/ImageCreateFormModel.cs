using Microsoft.AspNetCore.Components.Forms;
using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;
using MusicClub.Cms.Blazor.Abstractions;

namespace MusicClub.Cms.Blazor.Models.FormModels
{
    public class ImageCreateFormModel : IImageFormModel
    {
        [Required]
        public string? Alt { get; set; }

        [Required(ErrorMessage = "File is a required property")]
        [MaxFileSize]
        public IBrowserFile? BrowserFile { get; set; }
    }
}
