using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class GoogleEventFilterRequest : Sort
    {
        public string? GoogleIdentifier { get; set; }

        [Min(1)]
        public int? GoogleCalendarId { get; set; }

        [Min(1)]
        public int? ActId { get; set; }
    }
}