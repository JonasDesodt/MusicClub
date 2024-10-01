using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ArtistFilterRequest : Sort
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
