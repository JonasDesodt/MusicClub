using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class GoogleCalendarFilterRequest : Sort
    {
        public string? GoogleIdentifier { get; set; }
    }
}
