using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.GoogleEvent
{
    internal static class GoogleEventRequestExtensions
    {
        public static DbCore.Models.GoogleEvent ToModel(this GoogleEventRequest request, string googleIdentifier)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.GoogleEvent
            {
                Created = now,
                Updated = now,
                GoogleIdentifier = googleIdentifier,
                GoogleCalendarId = request.GoogleCalendarId,
            };
        }
    }
}
