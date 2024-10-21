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
    public class GoogleEventDbService(MusicClubDbContext dbContext) : IGoogleEventService
    {
        private const GoogleEventResult? EmptyDataResult = null;

        public async Task<ServiceResult<GoogleEventResult>> Create(GoogleEventRequest request)
        {
            if (dbContext.GoogleEvents.Any(g => g.GoogleIdentifier.ToLower() == request.GoogleIdentifier.ToLower() && g.GoogleCalendarId == request.GoogleCalendarId))
            {
                return EmptyDataResult.Wrap(new ServiceMessages().AddDuplicate(nameof(GoogleEvent)).AddNotCreated(nameof(GoogleEvent)));
            }

            var googleEvent = request.ToModel();

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
