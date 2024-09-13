namespace MusicClub.DbCore
{
    public class Performance
    {
        public int Id { get; set; }
        public required string Instrument { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public required int ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public required int ActId { get; set; }
        public Act? Act { get; set; }
    }
}