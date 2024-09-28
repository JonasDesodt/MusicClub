using MusicClub.Cms.Blazor.Interfaces;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    public class PerformanceFormModel : IImageSelect
    {
        [Required]
        public string? Instrument { get; set; }


        [Required]
        [Min(1)]
        public int? ActId { get; set; }
        public ActResult? ActResult { get; set; }

        [Required]
        [Min(1)]
        public int? ArtistId { get; set; }
        public ArtistResult? ArtistResult { get; set; }

        [Min(1)]
        public int? BandnameId { get; set; }
        public BandnameResult? BandnameResult { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
