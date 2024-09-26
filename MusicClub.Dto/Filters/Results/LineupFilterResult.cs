using MusicClub.Dto.Results;

namespace MusicClub.Dto.Filters.Results
{
   public class LineupFilterResult : Sort
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
