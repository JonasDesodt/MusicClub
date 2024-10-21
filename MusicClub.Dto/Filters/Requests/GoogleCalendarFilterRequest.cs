using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Extensions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class GoogleCalendarFilterRequest : Sort, IFilterRequestConverter<GoogleCalendarFilterResult>
    {
        public string? GoogleIdentifier { get; set; }

        public string ToQueryString()
        {
            return GoogleCalendarFilterRequestExtensions.ToQueryString(this);
        }

        public GoogleCalendarFilterResult ToResult()
        {
            return GoogleCalendarFilterRequestExtensions.ToResult(this);
        }
    }
}
