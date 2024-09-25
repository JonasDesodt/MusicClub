namespace MusicClub.Dto.Results
{
    public class ActResult
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }

        public DateTime? Start { get; set; }
        public int? Duration { get; set; }


        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public ImageResult? Image { get; set; }

        public required LineupResult Lineup {get;set;}

        public required int PerformancesCount { get; set; }

        public required int JobsCount { get; set; }
    }
}
