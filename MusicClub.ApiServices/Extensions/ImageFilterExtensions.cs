using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ImageFilterExtensions
    {
        public static string ToQueryString(this ImageFilter imageFilter)
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

        public static ImageFilter GetCopy(this ImageFilter imageFilter)
        {
            return new ImageFilter
            {
                Alt = imageFilter.Alt,                
                SortProperty = imageFilter.SortProperty,
                SortDirection = imageFilter.SortDirection
            };
        }
    }
}
