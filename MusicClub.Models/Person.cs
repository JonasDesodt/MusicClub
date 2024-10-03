namespace MusicClub.Models
{
    public class Person
    {
        public int Id { get; set; }

        public required string Firstname { get; set; }
        public required string Lastname { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public IList<Artist> Artists { get; set; } = [];

        public IList<Worker> Workers { get; set; } = [];

        public IList<ApplicationUser> ApplicationUsers { get; set; } = [];
    }
}
