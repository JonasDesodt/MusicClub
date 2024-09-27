using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions.Artist
{
    public static class ArtistFilterResultExtensions
    {
        public static ArtistFilterRequest ToRequest(this ArtistFilterResult result)
        {
            return new ArtistFilterRequest
            {
                SortProperty = result.SortProperty,
                SortDirection = result.SortDirection,
                Alias = result.Alias,
                Firstname = result.Firstname,
                Lastname = result.Lastname
            };
        }
    }
}
