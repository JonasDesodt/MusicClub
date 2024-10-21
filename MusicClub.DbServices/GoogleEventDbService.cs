using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.DbServices.Extensions.GoogleCalendar;
using MusicClub.DbServices.Extensions.GoogleEvent;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices
{
    public class GoogleEventDbService(MusicClubDbContext dbContext, CalendarService googleCalendarService) : IGoogleEventService
    {
        private const GoogleEventResult? EmptyDataResult = null;

        public async Task<ServiceResult<GoogleEventResult>> Create(GoogleEventRequest request)
        {
            var act = await dbContext.Acts.FindAsync(request.ActId);
            if (act is null)
            {
                return EmptyDataResult.Wrap();
            }

            if (act.GoogleEventId > 0)
            {
                return EmptyDataResult.Wrap();
            }

            if (act.Start is null)
            {
                return EmptyDataResult.Wrap();
            }

            if (!(act.Duration > 0))
            {
                return EmptyDataResult.Wrap();
            }


            var googleCalendar = await dbContext.GoogleCalendars.FindAsync(request.GoogleCalendarId);
            if (googleCalendar is null)
            {
                return EmptyDataResult.Wrap();
            }


            var eventRequest = new Event
            {
                Summary = act.Name,
                Description = act.Title,
                Start = new EventDateTime
                {
                    DateTimeRaw = act.Start?.ToString("o"),
                    TimeZone = "Europe/Brussels"
                },
                End = new EventDateTime
                {
                    DateTimeRaw = (act.Start?.AddMinutes((double)act.Duration))?.ToString("o"),
                    TimeZone = "Europe/Brussels"
                }
            };

            var eventResponse = await googleCalendarService.Events.Insert(eventRequest, googleCalendar.GoogleIdentifier).ExecuteAsync();
            if (eventResponse is null)
            {
                return EmptyDataResult.Wrap();
            }

            var googleEvent = request.ToModel(eventResponse.Id);

            await dbContext.GoogleEvents.AddAsync(googleEvent);
            await dbContext.SaveChangesAsync();

            return await Get(googleEvent.Id);
        }

        public Task<ServiceResult<GoogleEventResult>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<GoogleEventResult>> Get(int id)
        {
            return (await dbContext.GoogleEvents
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(GoogleEvent), id));
        }

        public Task<PagedServiceResult<IList<GoogleEventResult>, GoogleEventFilterResult>> GetAll(PaginationRequest paginationRequest, GoogleEventFilterRequest filterRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<GoogleEventResult>> Update(int id, GoogleEventRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
