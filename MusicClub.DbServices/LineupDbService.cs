using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Filters.Requests;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.Lineup;
using MusicClub.DbServices.Extensions.Service;
using MusicClub.Dto.Filters.Extensions;

namespace MusicClub.DbServices
{
    public class LineupDbService(MusicClubDbContext dbContext) : ILineupService
    {
        public async Task<ServiceResult<LineupResult>> Create(LineupRequest request)
        {
            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotCreated(nameof(Lineup)));
            }

            var lineup = request.ToModel();

            await dbContext.Lineups.AddAsync(lineup);

            await dbContext.SaveChangesAsync();

            return await Get(lineup.Id);
        }

        public async Task<ServiceResult<LineupResult>> Delete(int id)
        {
            if (await dbContext.Lineups.FindAsync(id) is not { } lineup)
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Lineup), id).AddNotDeleted(nameof(Lineup), id));
            }

            if (await dbContext.Acts.HasReferenceToLineup(id))
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Lineup), id, nameof(Act)).AddNotDeleted(nameof(Lineup), id));
            }

            if (await dbContext.Services.HasReferenceToLineup(id))
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Lineup), id, nameof(Service)).AddNotDeleted(nameof(Lineup), id));
            }

            dbContext.Lineups.Remove(lineup);

            await dbContext.SaveChangesAsync();

            return ((LineupResult?)null).Wrap();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<LineupResult>> Get(int id)
        {
            return (await dbContext.Lineups
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(Lineup), id));
        }

        public async Task<PagedServiceResult<IList<LineupResult>, LineupFilterResult>> GetAll(PaginationRequest paginationRequest, LineupFilterRequest filterRequest)
        {
            var totalCount = await dbContext.Lineups
                .IncludeAll()
                .Filter(filterRequest)
                .CountAsync();

            return (await dbContext.Lineups
                .IncludeAll()
                .Filter(filterRequest)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filterRequest.ToResult());
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<LineupResult>> Update(int id, LineupRequest request)
        {
            if (await dbContext.Lineups.IncludeAll().FirstOrDefaultAsync(p => p.Id == id) is not { } lineup)
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Lineup), id).AddNotUpdated(nameof(Lineup), id));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((LineupResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotUpdated(nameof(Lineup), id));
            }

            lineup.Update(request);

            await dbContext.SaveChangesAsync();

            return lineup.ToResult().Wrap();
        }
    }
}
