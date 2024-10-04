using MusicClub.Dto.Enums;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static  class ArtistFilterRequestExtensions
    {


        public static ArtistFilterRequest GetCopy(this ArtistFilterRequest artistFilter)
        {
            return new ArtistFilterRequest
            {
                Alias = artistFilter.Alias,
                Firstname = artistFilter.Firstname,
                Lastname = artistFilter.Lastname,
                SortProperty = artistFilter.SortProperty,
                SortDirection = artistFilter.SortDirection
            };
        }
    }
}