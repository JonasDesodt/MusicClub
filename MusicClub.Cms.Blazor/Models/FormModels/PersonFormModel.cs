using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Cms.Blazor.Models.FormModels
{
    public class PersonFormModel
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}