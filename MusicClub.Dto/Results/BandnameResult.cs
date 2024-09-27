namespace MusicClub.Dto.Results
{
    public class BandnameResult
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public ImageResult? Image { get; set; }

        public required BandResult Band { get; set; }

        public required int PerformancesCount { get; set; }
    }
}
