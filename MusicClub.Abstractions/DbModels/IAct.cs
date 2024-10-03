namespace MusicClub.Abstractions.DbModels
{
    public interface IAct : ITimestamps
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Title { get; set; }

        DateTime? Start { get; set; }
        int? Duration { get; set; }

        int? ImageId { get; set; }
        IImage? Image { get; set; }

        IList<IPerformance> Performances { get; set; }
        IList<IJob> Jobs { get; set; }

        int LineupId { get; set; }
        ILineup? Lineup { get; set; }
    }
}
