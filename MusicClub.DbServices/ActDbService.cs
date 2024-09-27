using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using MusicClub.Dto.Extensions;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.Lineup;
using MusicClub.DbServices.Extensions.Performance;
using MusicClub.DbServices.Extensions.Job;
using MusicClub.Dto.Extensions.Act;
using MusicClub.DbServices.Extensions.Image;

namespace MusicClub.DbServices
{
    public class ActDbService(MusicClubDbContext dbContext) : IActService
    {
        public async Task<ServiceResult<ActResult>> Create(ActRequest request)
        {
            if (!await dbContext.Lineups.ExistsOrIsNull(request.LineupId))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Lineup), request.LineupId).AddNotCreated(nameof(Act)));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotCreated(nameof(Act)));
            }

            var act = request.ToModel();

            await dbContext.Acts.AddAsync(act);

            await dbContext.SaveChangesAsync();

            return await Get(act.Id);
        }

        public async Task<ServiceResult<ActResult>> Delete(int id)
        {
            if (await dbContext.Acts.FindAsync(id) is not { } act)
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Act), id).AddNotDeleted(nameof(Act), id));
            }

            if (await dbContext.Performances.HasReferenceToAct(id))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Act), id, nameof(Performance)).AddNotDeleted(nameof(Act), id));
            }

            if (await dbContext.Jobs.HasReferenceToAct(id))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Act), id, nameof(Job)).AddNotDeleted(nameof(Act), id));
            }

            dbContext.Acts.Remove(act);

            await dbContext.SaveChangesAsync();

            return ((ActResult?)null).Wrap();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ActResult>> Get(int id)
        {
            return (await dbContext.Acts
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(Act), id));
        }

        public async Task<PagedServiceResult<IList<ActResult>, ActFilterResult>> GetAll(PaginationRequest paginationRequest, ActFilterRequest filterRequest)
        {
            var filterResult = filterRequest.ToResult();

            if (filterRequest.ImageId > 0)
            {
                if (await dbContext.Images
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.ImageId) is not { } imageResult)
                {
                    return ((IList<ActResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Image), filterRequest.ImageId));
                }
                else
                {
                    filterResult.Image = imageResult;
                }
            }

            if (filterRequest.LineupId > 0)
            {
                if(await dbContext.Lineups
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.LineupId) is not { } lineupResult)
                {
                    return ((IList<ActResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Lineup), filterRequest.LineupId));
                }
                else
                {
                    filterResult.Lineup = lineupResult;
                }
            }  

            var totalCount = await dbContext.Acts
                .IncludeAll()
                .Filter(filterRequest)
                .CountAsync();

            return (await dbContext.Acts
                .IncludeAll()
                .Filter(filterRequest)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filterResult);
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ActResult>> Update(int id, ActRequest request)
        {
            if (await dbContext.Acts.IncludeAll().FirstOrDefaultAsync(p => p.Id == id) is not { } act)
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Act), id).AddNotUpdated(nameof(Act), id));
            }

            if (!await dbContext.Lineups.ExistsOrIsNull(request.LineupId))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Lineup), request.LineupId).AddNotUpdated(nameof(Act), id));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((ActResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotUpdated(nameof(Act), id));
            }

            act.Update(request);

            await dbContext.SaveChangesAsync();

            return act.ToResult().Wrap();
        }
    }
}
