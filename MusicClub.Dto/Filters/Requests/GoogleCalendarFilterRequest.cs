using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class GoogleCalendarFilterRequest : Sort//, IFilterRequestConverter<GoogleCalendarFilterResult>
    {
        public string? GoogleIdentifier { get; set; }

        //public string ToQueryString()
        //{
        //    return GoogleCalendarFilterRequestExtensions.ToQueryString(this);
        //}

        //public GoogleCalendarFilterResult ToResult()
        //{
        //    return GoogleCalendarFilterRequestExtensions.ToResult(this);
        //}
    }
}
