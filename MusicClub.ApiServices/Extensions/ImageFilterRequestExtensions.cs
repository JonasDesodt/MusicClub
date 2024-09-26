using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ImageFilterRequestExtensions
    {
        public static string ToQueryString(this ImageFilterRequest imageFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(imageFilter.Alt))
            {
                builder.Append($"&alt={imageFilter.Alt}");
            }

            if (!string.IsNullOrWhiteSpace(imageFilter.SortProperty))
            {
                builder.Append($"&sortProperty={imageFilter.SortProperty}");

                if (imageFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&sortDirection={imageFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static ImageFilterRequest GetCopy(this ImageFilterRequest imageFilter)
        {
            return new ImageFilterRequest
            {
                Alt = imageFilter.Alt,                
                SortProperty = imageFilter.SortProperty,
                SortDirection = imageFilter.SortDirection
            };
        }
    }
}
