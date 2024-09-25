using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ActFilterExtensions
    {
        public static string ToQueryString(this ActFilter actFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(actFilter.Name))
            {
                builder.Append($"&{nameof(ActFilter.Name)}={actFilter.Name}");
            }

            if (!string.IsNullOrWhiteSpace(actFilter.Title))
            {
                builder.Append($"&{nameof(ActFilter.Title)}={actFilter.Title}");
            }

            if (actFilter.Duration >= 0)
            {
                builder.Append($"&{nameof(ActFilter.Duration)}={actFilter.Duration}");
            }

            if(actFilter.Start is not null)
            {
                builder.Append($"&{nameof(ActFilter.Start)}={actFilter.Start}");
            }

            if(actFilter.ImageId > 0)
            {
                builder.Append($"&{nameof(ActFilter.ImageId)}={actFilter.ImageId}");
            }

            if (actFilter.LineupId > 0)
            {
                builder.Append($"&{nameof(ActFilter.LineupId)}={actFilter.LineupId}");
            }

            if (!string.IsNullOrWhiteSpace(actFilter.SortProperty))
            {
                builder.Append($"&{nameof(ActFilter.SortProperty)}={actFilter.SortProperty}");

                if (actFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&{nameof(ActFilter.SortDirection)}={actFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static ActFilter GetCopy(this ActFilter actFilter)
        {
            return new ActFilter
            {
                SortProperty = actFilter.SortProperty,
                SortDirection = actFilter.SortDirection,
                Name = actFilter.Name,
                Title = actFilter.Title,
                Duration = actFilter.Duration,
                ImageId = actFilter.ImageId,
                LineupId = actFilter.LineupId,
                Start = actFilter.Start
            };
        }
    }
}
