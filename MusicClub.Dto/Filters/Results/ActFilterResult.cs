using MusicClub.Dto.Results;

namespace MusicClub.Dto.Filters.Results
{
    public class ActFilterResult : Sort
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        public int? Duration { get; set; }

        public int? LineupId { get; set; }
        public LineupResult? Lineup { get; set; }

        public int? ImageId { get; set; }
        public ImageResult? Image { get; set; }
    }
}
