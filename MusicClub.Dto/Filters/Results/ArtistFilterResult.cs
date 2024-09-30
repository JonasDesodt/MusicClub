using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Artist;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Dto.Filters.Results
{
    public class ArtistFilterResult : Sort, IConvertToRequest<ArtistFilterRequest>
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public ArtistFilterRequest ToRequest()
        {
            return ArtistFilterResultExtensions.ToRequest(this);
        }
    }
}
