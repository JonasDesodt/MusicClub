using MusicClub.Dto.Results;
using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    public class ArtistFormModel
    {
        public string? Alias { get; set; }

        [Required]
        [Min(1)]
        public int? PersonId { get; set; }
        public PersonResult? PersonResult { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}