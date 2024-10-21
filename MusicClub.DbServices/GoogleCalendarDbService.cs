using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.GoogleCalendar;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices
{
    public class GoogleCalendarDbService(MusicClubDbContext dbContext) : IGoogleCalendarService
    {
        private const GoogleCalendarResult? EmptyDataResult = null; 

        public async Task<ServiceResult<GoogleCalendarResult>> Create(GoogleCalendarRequest request)
        {
            if (dbContext.GoogleCalendars.Any(g => g.GoogleIdentifier.ToLower() == request.GoogleIdentifier.ToLower()))
            {
                return EmptyDataResult.Wrap(new ServiceMessages().AddDuplicate(nameof(GoogleCalendar)).AddNotCreated(nameof(GoogleCalendar)));
            }

            var googleCalendar = request.ToModel();

            await dbContext.GoogleCalendars.AddAsync(googleCalendar);

            await dbContext.SaveChangesAsync();

            return await Get(googleCalendar.Id);
        }

        public Task<ServiceResult<GoogleCalendarResult>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<GoogleCalendarResult>> Get(int id)
        {
            return (await dbContext.GoogleCalendars
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(GoogleCalendar), id));
        }

        public Task<PagedServiceResult<IList<GoogleCalendarResult>, GoogleCalendarFilterResult>> GetAll(PaginationRequest paginationRequest, GoogleCalendarFilterRequest filterRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<GoogleCalendarResult>> Update(int id, GoogleCalendarRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
