namespace MusicClub.Dto.Filters.Requests
{
    public class ArtistFilterRequest : Sort
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
