using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class LineupFilterRequest : Sort
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        public int? ImageId { get; set; }
    }
}
