namespace MusicClub.Dto.Results
{
    public class PerformanceResult
    {
        public required int Id { get; set; }
        public required string Instrument { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public ImageResult? Image { get; set; }

        public required ArtistResult Artist { get; set; }

        public required ActResult Act { get; set; }

        public BandnameResult? Bandname { get; set; }
    }
}
