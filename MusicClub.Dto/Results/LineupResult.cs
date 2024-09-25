namespace MusicClub.Dto.Results
{
    public class LineupResult
    {
        public required int Id { get; set; }
        public string? Title { get; set; }
        public required DateTime Doors { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public ImageResult? Image { get; set; }

        public required int ActsCount { get; set; }

        public required int ServicesCount { get; set; }
    }
}
