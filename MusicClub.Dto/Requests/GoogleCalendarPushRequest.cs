using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Requests
{
    public class GoogleCalendarPushRequest
    {
        public required int ActId { get; set; }

        [Min(1)]
        public required int GoogleCalendarId { get; set; }
    }
}
