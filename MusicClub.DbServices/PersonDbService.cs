using MusicClub.Dto.Abstractions;
using MusicClub.DbCore;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.DbServices.Extensions.Artist;
using MusicClub.DbServices.Extensions.Person;
using MusicClub.DbServices.Extensions.Worker;
using MusicClub.Dto.Filters.Extensions;

namespace MusicClub.DbServices
{
    public class PersonDbService(MusicClubDbContext dbContext) : IPersonService
    {
        public async Task<ServiceResult<PersonResult>> Create(PersonRequest request)
        {
            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotCreated(nameof(Person)));
            }

            var person = request.ToModel();

            await dbContext.People.AddAsync(person);

            await dbContext.SaveChangesAsync();

            return await Get(person.Id);
        }

        public async Task<ServiceResult<PersonResult>> Delete(int id)
        {
            if (await dbContext.People.FindAsync(id) is not { } person)
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Person), id).AddNotDeleted(nameof(Person), id));
            }

            if (await dbContext.Artists.HasReferenceToPerson(id))
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Person), id, nameof(Artist)).AddNotDeleted(nameof(Person), id));
            }

            if (await dbContext.Workers.HasReferenceToPerson(id))
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Person), id, nameof(Worker)).AddNotDeleted(nameof(Person), id));
            }

            dbContext.People.Remove(person);

            await dbContext.SaveChangesAsync();

            return ((PersonResult?)null).Wrap();
        }

        public async Task<ServiceResult<bool>> Exists(int id)
        {
            return (await dbContext.People.FindAsync(id) is not null).Wrap();
        }

        //todo: hide people who are only applicationusers?
        public async Task<ServiceResult<PersonResult>> Get(int id)
        {
            return (await dbContext.People
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(Person), id));
        }

        //todo: hide people who are only applicationusers?
        public async Task<PagedServiceResult<IList<PersonResult>, PersonFilterResult>> GetAll(PaginationRequest paginationRequest, PersonFilterRequest filterRequest)
        {
            var totalCount = await dbContext.People
                .IncludeAll()
                .Filter(filterRequest)
                .CountAsync();

            return (await dbContext.People
                .IncludeAll()
                .Filter(filterRequest)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filterRequest.ToResult());
        }

        public async Task<ServiceResult<bool>> IsReferenced(int id)
        {
            if (await dbContext.Artists.HasReferenceToPerson(id))
            {
                return true.Wrap();
            }

            if (await dbContext.Workers.HasReferenceToPerson(id))
            {
                return true.Wrap();
            }

            return false.Wrap();
        }

        public async Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
        {
            if (await dbContext.People.IncludeAll().FirstOrDefaultAsync(p => p.Id == id) is not { } person)
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Person), id).AddNotUpdated(nameof(Person), id));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((PersonResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotUpdated(nameof(Person), id));
            }

            person.Update(request);

            await dbContext.SaveChangesAsync();

            return person.ToResult().Wrap();
        }
    }
}