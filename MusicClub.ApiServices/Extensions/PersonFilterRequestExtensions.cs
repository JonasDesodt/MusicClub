﻿using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class PersonFilterRequestExtensions
    {
        public static string ToQueryString(this PersonFilterRequest personFilter)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(personFilter.Firstname))
            {
                builder.Append($"&firstname={personFilter.Firstname}");
            }

            if (!string.IsNullOrWhiteSpace(personFilter.Lastname))
            {
                builder.Append($"&lastname={personFilter.Lastname}");
            }

            if (!string.IsNullOrWhiteSpace(personFilter.SortProperty))
            {
                builder.Append($"&sortProperty={personFilter.SortProperty}");

                if (personFilter.SortDirection is SortDirection.Descending)
                {
                    builder.Append($"&sortDirection={personFilter.SortDirection}");
                }
            }

            return builder.ToString();
        }

        public static PersonFilterRequest GetCopy(this PersonFilterRequest personFilter)
        {
            return new PersonFilterRequest
            {
                Firstname = personFilter.Firstname,
                Lastname = personFilter.Lastname,
                SortProperty = personFilter.SortProperty,
                SortDirection = personFilter.SortDirection
            };
        }
    }
}