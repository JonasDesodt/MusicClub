using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions.GoogleCalendar
{
    internal static class GoogleCalendarExtensions
    {
        public static IQueryable<DbCore.Models.GoogleCalendar> IncludeAll(this IQueryable<DbCore.Models.GoogleCalendar> query)
        {
            return query.Include(g => g.GoogleEvents);
        }

        public static IQueryable<GoogleCalendarResult> ToResults(this IQueryable<DbCore.Models.GoogleCalendar> query)
        {
            return query.Select(a => new GoogleCalendarResult
            {
                GoogleEventsCount = a.GoogleEvents.Count,
                GoogleIdentifier = a.GoogleIdentifier,
                Created = a.Created,
                Id = a.Id,
                Updated = a.Updated,
            });
        }

        public static GoogleCalendarResult ToResult(this DbCore.Models.GoogleCalendar googleCalendar)
        {
            return new GoogleCalendarResult
            {
                GoogleEventsCount = googleCalendar.GoogleEvents.Count,
                GoogleIdentifier = googleCalendar.GoogleIdentifier,
                Created = googleCalendar.Created,
                Id = googleCalendar.Id,
                Updated = googleCalendar.Updated,
            };
        }
    }
}
