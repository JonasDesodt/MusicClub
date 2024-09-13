namespace MusicClub.Dto.Filters
{
    public class ArtistFilter : Sort
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
