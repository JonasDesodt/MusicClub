using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.DbServices.Extensions.Artist;
using MusicClub.DbServices.Extensions.Performance;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using MusicClub.DbServices.Extensions.Image;
using MusicClub.DbServices.Extensions.Lineup;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.Bandname;

namespace MusicClub.DbServices
{
    public class PerformanceDbService(MusicClubDbContext dbContext) : IPerformanceService
    {
        public async Task<ServiceResult<PerformanceResult>> Create(PerformanceRequest request)
        {
            if (!await dbContext.Acts.ExistsOrIsNull(request.ActId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Act), request.ActId).AddNotCreated(nameof(Performance)));
            }

            if (!await dbContext.Artists.ExistsOrIsNull(request.ArtistId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Artist), request.ArtistId).AddNotCreated(nameof(Performance)));
            }

            if (!await dbContext.Bandnames.ExistsOrIsNull(request.BandnameId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Bandname), request.BandnameId).AddNotCreated(nameof(Performance)));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotCreated(nameof(Performance)));
            }

            var performance = request.ToModel();

            await dbContext.Performances.AddAsync(performance);

            await dbContext.SaveChangesAsync();

            return await Get(performance.Id);
        }

        public async Task<ServiceResult<PerformanceResult>> Delete(int id)
        {
            if (await dbContext.Performances.FindAsync(id) is not { } performance)
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Performance), id).AddNotDeleted(nameof(Performance), id));
            }

            dbContext.Performances.Remove(performance);

            await dbContext.SaveChangesAsync();

            return ((PerformanceResult?)null).Wrap();
        }
        
        public async Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<PerformanceResult>> Get(int id)
        {
            return (await dbContext.Performances
             .IncludeAll()
             .ToResults()
             .FirstOrDefaultAsync(p => p.Id == id))
             .Wrap(new ServiceMessages().AddNotFound(nameof(Performance), id));
        }

        public async Task<PagedServiceResult<IList<PerformanceResult>, PerformanceFilterResult>> GetAll(PaginationRequest paginationRequest, PerformanceFilterRequest filterRequest)
        {
            var filterResult = filterRequest.ToResult();

            if (filterRequest.ActId > 0)
            {
                if (await dbContext.Acts
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.ActId) is not { } actResult)
                {
                    return ((IList<PerformanceResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Act), filterRequest.ActId));
                }
                else
                {
                    filterResult.ActResult = actResult;
                }
            }

            if (filterRequest.ArtistId > 0)
            {
                if (await dbContext.Artists
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.ArtistId) is not { } artistResult)
                {
                    return ((IList<PerformanceResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Artist), filterRequest.ArtistId));
                }
                else
                {
                    filterResult.ArtistResult = artistResult;
                }
            }

            if (filterRequest.BandnameId > 0)
            {
                if (await dbContext.Bandnames
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.BandnameId) is not { } bandnameResult)
                {
                    return ((IList<PerformanceResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Bandname), filterRequest.BandnameId));
                }
                else
                {
                    filterResult.BandnameResult = bandnameResult;
                }
            }

            if (filterRequest.ImageId > 0)
            {
                if (await dbContext.Images
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(i => i.Id == filterRequest.ImageId) is not { } imageResult)
                {
                    return ((IList<PerformanceResult>?)null).Wrap(paginationRequest, 0, filterRequest.ToResult(), new ServiceMessages().AddNotFound(nameof(Image), filterRequest.ImageId));
                }
                else
                {
                    filterResult.ImageResult = imageResult;
                }
            }

            var totalCount = await dbContext.Performances
                .IncludeAll()
                .Filter(filterRequest)
                .CountAsync();

            return (await dbContext.Performances
                .IncludeAll()
                .Filter(filterRequest)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filterRequest.ToResult());
        }

        public async Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<PerformanceResult>> Update(int id, PerformanceRequest request)
        {
            if (await dbContext.Performances.IncludeAll().FirstOrDefaultAsync(p => p.Id == id) is not { } performance)
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Performance), id).AddNotUpdated(nameof(Performance), id));
            }


            if (!await dbContext.Acts.ExistsOrIsNull(request.ActId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Act), id).AddNotUpdated(nameof(Performance), id));
            }

            if (!await dbContext.Artists.ExistsOrIsNull(request.ArtistId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Artist), request.ArtistId).AddNotUpdated(nameof(Performance), id));
            }

            if (!await dbContext.Bandnames.ExistsOrIsNull(request.BandnameId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Bandname), request.BandnameId).AddNotUpdated(nameof(Performance), id));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((PerformanceResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotUpdated(nameof(Performance), id));
            }

            performance.Update(request);

            await dbContext.SaveChangesAsync();

            return performance.ToResult().Wrap();
        }
    }
}
