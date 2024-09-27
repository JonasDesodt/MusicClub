using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions.Artist
{
    public static class ArtistFilterRequestExtensions
    {
        public static ArtistFilterResult ToResult(this ArtistFilterRequest request)
        {
            return new ArtistFilterResult
            {
                SortProperty = request.SortProperty,
                SortDirection = request.SortDirection,
                Alias = request.Alias,
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };
        }
    }
}