using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class ImageFilterExtensions
    {
        public static string ToQueryString(this ImageFilter imageFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(imageFilter.Alt))
            {
                builder.Append($"&alias={imageFilter.Alt}");
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
    }
}
