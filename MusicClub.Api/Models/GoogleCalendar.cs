namespace MusicClub.Api.Models
{
    public class CalendarEvent
    {
        public required string Summary { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public required EventDateTime Start { get; set; }
        public required EventDateTime End { get; set; }
        public List<Attendee> Attendees { get; set; } = [];
    }

    public class EventDateTime
    {
        public required string DateTime { get; set; }
        public required string TimeZone { get; set; }
    }

    public class Attendee
    {
        public required string Email { get; set; }
    }
}
