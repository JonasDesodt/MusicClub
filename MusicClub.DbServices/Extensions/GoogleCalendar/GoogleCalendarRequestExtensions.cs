using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.GoogleCalendar
{
    internal static class GoogleCalendarRequestExtensions
    {
        public static DbCore.Models.GoogleCalendar ToModel(this GoogleCalendarRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.GoogleCalendar
            {
                Created = now,
                Updated = now,
                GoogleIdentifier = request.GoogleIdentifier,
            };
        }
    }
}