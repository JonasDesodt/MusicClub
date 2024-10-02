using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class PerformanceFilterRequest : Sort, IFilterRequestConverter<PerformanceFilterResult>
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

        public string ToQueryString()
        {
            return "";
        }

        public PerformanceFilterResult ToResult()
        {
            return PerformanceFilterRequestExtensions.ToResult(this);
        }
    }
}
