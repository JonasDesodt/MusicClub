using Microsoft.AspNetCore.Components.Forms;
using MusicClub.Dto.Attributes;
using MusicClub.Cms.Blazor.Abstractions;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    public class ImageEditDataFormModel : IImageFormModel
    {
        [Required]
        public required string? Alt { get; set; }

        [MaxFileSize]
        public IBrowserFile? BrowserFile { get; set; }
    }
}
