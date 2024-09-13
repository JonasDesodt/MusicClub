using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class PersonFilterExtensions
    {
        public static string ToQueryString(this PersonFilter personFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(personFilter.Firstname))
            {
                builder.Append($"name={personFilter.Firstname}&");
            }

            if (!string.IsNullOrWhiteSpace(personFilter.Lastname))
            {
                builder.Append($"name={personFilter.Lastname}&");
            }

            if (!string.IsNullOrWhiteSpace(personFilter.SortProperty))
            {
                builder.Append($"sortProperty={personFilter.SortProperty}&");

                if (personFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"sortDirection={personFilter.SortDirection}&");
                }
            }

            return builder.ToString();
        }
    }
}