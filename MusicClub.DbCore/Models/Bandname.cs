namespace MusicClub.DbCore.Models
{
    public class Bandname
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public int BandId { get; set; }
        public Band? Band { get; set; }

        public IList<Performance> Performances { get; set; } = [];
    }
}