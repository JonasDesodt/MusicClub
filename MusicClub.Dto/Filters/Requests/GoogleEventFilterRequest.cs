using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Extensions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class GoogleEventFilterRequest : Sort, IFilterRequestConverter<GoogleEventFilterResult>
    {
        public string? GoogleIdentifier { get; set; }

        [Min(1)]
        public int? GoogleCalendarId { get; set; }

        [Min(1)]
        public int? ActId { get; set; }

        public string ToQueryString()
        {
            return GoogleEventFilterRequestExtensions.ToQueryString(this);
        }

        public GoogleEventFilterResult ToResult()
        {
            return GoogleEventFilterRequestExtensions.ToResult(this);
        }
    }
}