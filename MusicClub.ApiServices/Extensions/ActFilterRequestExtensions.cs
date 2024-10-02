using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ActFilterRequestExtensions
    {
        public static string ToQueryString(this ActFilterRequest actFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(actFilter.Name))
            {
                builder.Append($"&{nameof(ActFilterRequest.Name)}={actFilter.Name}");
            }

            if (!string.IsNullOrWhiteSpace(actFilter.Title))
            {
                builder.Append($"&{nameof(ActFilterRequest.Title)}={actFilter.Title}");
            }

            if (actFilter.Duration >= 0)
            {
                builder.Append($"&{nameof(ActFilterRequest.Duration)}={actFilter.Duration}");
            }

            if (actFilter.Start is not null)
            {
                builder.Append($"&{nameof(ActFilterRequest.Start)}={actFilter.Start}");
            }

            if (actFilter.ImageId > 0)
            {
                builder.Append($"&{nameof(ActFilterRequest.ImageId)}={actFilter.ImageId}");
            }

            if (actFilter.LineupId > 0)
            {
                builder.Append($"&{nameof(ActFilterRequest.LineupId)}={actFilter.LineupId}");
            }

            if (!string.IsNullOrWhiteSpace(actFilter.SortProperty))
            {
                builder.Append($"&{nameof(ActFilterRequest.SortProperty)}={actFilter.SortProperty}");

                if (actFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&{nameof(ActFilterRequest.SortDirection)}={actFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static ActFilterRequest GetCopy(this ActFilterRequest actFilter)
        {
            return new ActFilterRequest
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
