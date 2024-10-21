namespace MusicClub.DbCore.Models
{
    public class GoogleCalendar
    {
        public int Id { get; set; }

        public required string GoogleIdentifier { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public IList<GoogleEvent> GoogleEvents { get; set; } = [];
    }
}
