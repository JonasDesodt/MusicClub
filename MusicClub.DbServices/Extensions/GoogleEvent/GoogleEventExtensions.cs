using Microsoft.EntityFrameworkCore;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.Dto.Results;
using MusicClub.DbServices.Extensions.GoogleCalendar;

namespace MusicClub.DbServices.Extensions.GoogleEvent
{
    internal static class GoogleEventExtensions
    {
        public static IQueryable<DbCore.Models.GoogleEvent> IncludeAll(this IQueryable<DbCore.Models.GoogleEvent> query)
        {
            return query.Include(g => g.Act).Include(g => g.GoogleCalendar);
        }

        public static IQueryable<GoogleEventResult> ToResults(this IQueryable<DbCore.Models.GoogleEvent> query)
        {
            return query.Select(a => new GoogleEventResult
            {
                GoogleIdentifier = a.GoogleIdentifier,
                Created = a.Created,
                Id = a.Id,
                Updated = a.Updated,
                ActResult = a.Act != null ? a.Act.ToResult() : null!, //TODO: temp hack (!), deal w/ null reference
                GoogleCalendarResult = a.GoogleCalendar!.ToResult()  //TODO: temp hack (!), deal w/ null reference
            });
        }

        public static GoogleEventResult ToResult(this DbCore.Models.GoogleEvent googleEvent)
        {
            return new GoogleEventResult
            {
                GoogleIdentifier = googleEvent.GoogleIdentifier,
                Created = googleEvent.Created,
                Id = googleEvent.Id,
                Updated = googleEvent.Updated,
                ActResult = googleEvent.Act != null ? googleEvent.Act.ToResult() : null!, //TODO: temp hack (!), deal w/ null reference
                GoogleCalendarResult = googleEvent.GoogleCalendar != null ? googleEvent.GoogleCalendar.ToResult() : null! //TODO: temp hack (!), deal w/ null reference
            };
        }
    }
}
