using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class PerformanceFilterRequestExtensions
    {
        public static string ToQueryString(this PerformanceFilterRequest filterRequest)
        {
            var builder = new StringBuilder();

            if (filterRequest.ActId > 0)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.ActId)}={filterRequest.ActId}");
            }

            if (filterRequest.ArtistId > 0)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.ArtistId)}={filterRequest.ArtistId}");
            }

            if (filterRequest.BandnameId > 0)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.BandnameId)}={filterRequest.BandnameId}");
            }

            if (filterRequest.Created is not null)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.Created)}={filterRequest.Created}");
            }

            if (filterRequest.ImageId > 0)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.ImageId)}={filterRequest.ImageId}");
            }

            if (filterRequest.Updated is not null)
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.Updated)}={filterRequest.Updated}");
            }

            if (!string.IsNullOrWhiteSpace(filterRequest.SortProperty))
            {
                builder.Append($"&{nameof(PerformanceFilterRequest.SortProperty)}={filterRequest.SortProperty}");

                if (filterRequest.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&{nameof(PerformanceFilterRequest.SortDirection)}={filterRequest.SortDirection}");
                }
            }

            return builder.ToString();
        }

    }
}
