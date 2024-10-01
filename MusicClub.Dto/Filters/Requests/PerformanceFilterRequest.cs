using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class PerformanceFilterRequest : Sort
    {
        public string? Instrument { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        [Min(1)]
        public int? ArtistId { get; set; }

        [Min(1)]
        public int? ActId { get; set; }

        [Min(1)]
        public int? BandnameId { get; set; }
    }
}
