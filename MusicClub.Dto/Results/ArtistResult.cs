namespace MusicClub.Dto.Results
{
    public class ArtistResult
    {
        public required int Id { get; set; }

        public string? Alias { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public PersonResult? Person { get; set; }

        public ImageResult? Image { get; set; }

        public required int PerformancesCount { get; set; }
    }
}
