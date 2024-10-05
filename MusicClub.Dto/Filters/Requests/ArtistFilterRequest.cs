using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ArtistFilterRequest : Sort, IFilterRequestConverter<ArtistFilterResult>
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string ToQueryString()
        {
            return ArtistFilterRequestExtensions.ToQueryString(this);
        }

        public ArtistFilterResult ToResult()
        {
            return ArtistFilterRequestExtensions.ToResult(this);
        }
    }
}
