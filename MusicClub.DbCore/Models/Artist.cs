using MusicClub.DbCore.Interfaces;

namespace MusicClub.DbCore.Models
{
    public class Artist : IPerson
    {
        public int Id { get; set; }

        public string? Alias { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public required int PersonId { get; set; }
        public Person? Person { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public IList<Performance> Performances { get; set; } = [];
    }
}