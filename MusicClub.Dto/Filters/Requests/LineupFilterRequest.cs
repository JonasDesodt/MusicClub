using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class LineupFilterRequest : Sort, IFilterRequestConverter<LineupFilterResult>
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        public string ToQueryString()
        {
            return LineupFilterRequestExtensions.ToQueryString(this);
        }

        public LineupFilterResult ToResult()
        {
            return LineupFilterRequestExtensions.ToResult(this);
        }
    }
}
