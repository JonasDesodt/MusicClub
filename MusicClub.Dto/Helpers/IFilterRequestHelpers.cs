using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Helpers
{
    [GenerateFilterRequestHelpers("Act", "Artist", "GoogleCalendar", "GoogleEvent", "Image", "Lineup", "Performance", "Person")]
    public interface IFilterRequestHelpers<TFilterRequest, TFilterResult>
    {
        string ToQueryString(TFilterRequest filterRequest);

        TFilterResult ToResult(TFilterRequest filterRequest);
    }
}