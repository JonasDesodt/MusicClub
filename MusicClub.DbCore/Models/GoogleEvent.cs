namespace MusicClub.DbCore.Models
{
    public class GoogleEvent
    {
        public int Id { get; set; }
            
        public required string GoogleIdentifier { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public required int GoogleCalendarId { get; set; }
        public GoogleCalendar? GoogleCalendar { get; set; }

        public Act? Act { get; set; }
    }
}
