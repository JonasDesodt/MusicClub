using MusicClub.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClub.DbServices.Extensions.GoogleEvent
{
    internal static class GoogleEventRequestExtensions
    {
        public static DbCore.Models.GoogleEvent ToModel(this GoogleEventRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.GoogleEvent
            {
                Created = now,
                Updated = now,
                GoogleIdentifier = request.GoogleIdentifier,
                GoogleCalendarId = request.GoogleCalendarId,
            };
        }
    }
}
