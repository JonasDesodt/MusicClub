using MusicClub.Dto.Enums;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static  class ArtistFilterRequestExtensions
    {
        public static string ToQueryString(this ArtistFilterRequest artistFilter)
        {           
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(artistFilter.Alias))
            {
                builder.Append($"&alias={artistFilter.Alias}");
            }

            if (!string.IsNullOrWhiteSpace(artistFilter.Firstname))
            {
                builder.Append($"&firstname={artistFilter.Firstname}");
            }

            if (!string.IsNullOrWhiteSpace(artistFilter.Lastname))
            {
                builder.Append($"&lastname={artistFilter.Lastname}");
            }

            if (!string.IsNullOrWhiteSpace(artistFilter.SortProperty))
            {
                builder.Append($"&sortProperty={artistFilter.SortProperty}");

                if (artistFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&sortDirection={artistFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

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