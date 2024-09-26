using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class LineupFilterRequestExtensions
    {
        public static string ToQueryString(this LineupFilterRequest lineupFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(lineupFilter.Title))
            {
                builder.Append($"&{nameof(LineupFilterRequest.Title)}={lineupFilter.Title}");
            }

            if (lineupFilter.Doors is not null)
            {
                builder.Append($"&{nameof(LineupFilterRequest.Doors)}={lineupFilter.Doors}");
            }

            if (lineupFilter.ImageId > 0)
            {
                builder.Append($"&{nameof(LineupFilterRequest.ImageId)}={lineupFilter.ImageId}");
            }

            if (!string.IsNullOrWhiteSpace(lineupFilter.SortProperty))
            {
                builder.Append($"&{nameof(LineupFilterRequest.SortProperty)}={lineupFilter.SortProperty}");

                if (lineupFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&{nameof(LineupFilterRequest.SortDirection)}={lineupFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static LineupFilterRequest GetCopy(this LineupFilterRequest lineupFilter)
        {
            return new LineupFilterRequest
            {
                Title = lineupFilter.Title,
                Doors = lineupFilter.Doors,
                ImageId = lineupFilter.ImageId,
                SortProperty = lineupFilter.SortProperty,
                SortDirection = lineupFilter.SortDirection
            };
        }
    }
}
