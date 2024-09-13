namespace MusicClub.DbCore.Models
{
    public class Lineup
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public required DateTime Doors { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public IList<Act> Acts { get; set; } = [];

        public IList<Service> Services { get; set; } = [];
    }
}