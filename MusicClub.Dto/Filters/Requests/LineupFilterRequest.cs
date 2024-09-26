namespace MusicClub.Dto.Filters.Requests
{
    public class LineupFilterRequest : Sort
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        public int? ImageId { get; set; }
    }
}
