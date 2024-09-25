namespace MusicClub.Dto.Filters
{
    public class LineupFilter : Sort
    {
        public string? Title { get; set; }
       
        public DateTime? Doors { get; set; }

        public int? ImageId { get; set; }
    }
}
