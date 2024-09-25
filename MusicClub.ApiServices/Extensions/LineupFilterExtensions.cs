using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class LineupFilterExtensions
    {
        public static string ToQueryString(this LineupFilter lineupFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(lineupFilter.Title))
            {
                builder.Append($"&{nameof(LineupFilter.Title)}={lineupFilter.Title}");
            }

            if (lineupFilter.Doors is not null)
            {
                builder.Append($"&{nameof(LineupFilter.Doors)}={lineupFilter.Doors}");
            }

            if (lineupFilter.ImageId > 0)
            {
                builder.Append($"&{nameof(LineupFilter.ImageId)}={lineupFilter.ImageId}");
            }

            if (!string.IsNullOrWhiteSpace(lineupFilter.SortProperty))
            {
                builder.Append($"&{nameof(LineupFilter.SortProperty)}={lineupFilter.SortProperty}");

                if (lineupFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&{nameof(LineupFilter.SortDirection)}={lineupFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static LineupFilter GetCopy(this LineupFilter lineupFilter)
        {
            return new LineupFilter
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
