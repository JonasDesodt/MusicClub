using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;
using MusicClub.Cms.Blazor.Interfaces;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    internal class PerformanceFilterFormModel : Sort, IImageSelect
    {
        public string? Instrument { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        [Min(1)]
        public int? ActId { get; set; }
        public ActResult? Act { get; set; }

        [Min(1)]
        public int? ArtistId { get; set; }
        public ArtistResult? Artist { get; set; }

        [Min(1)]
        public int? BandnameId { get; set; }
        public BandnameResult? Bandname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
