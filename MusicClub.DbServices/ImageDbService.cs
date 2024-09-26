using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Abstractions;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using MusicClub.Dto.Extensions;

namespace MusicClub.DbServices
{
    public class ImageDbService(MusicClubDbContext dbContext) : IImageDbService
    {
        public async Task<ServiceResult<ImageResult>> Create(ImageDbRequest request)
        {
            var image = request.ToModel();

            if (image is null)
            {
                return ((ImageResult?)null).Wrap(new ServiceMessages().AddNotCreated(nameof(Image)));
            }

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            return await Get(image.Id);
        }

        public async Task<ServiceResult<ImageResult>> Delete(int id)
        {
            if (await dbContext.Images.FindAsync(id) is not { } image)
            {
                return ((ImageResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), id).AddNotDeleted(nameof(Image), id));
            }

            if (await dbContext.Artists.FirstOrDefaultAsync(a => a.ImageId == id) is { } artist)
            {
                artist.ImageId = null;
                dbContext.Update(artist);

                await dbContext.SaveChangesAsync();
            }

            if (await dbContext.Acts.FirstOrDefaultAsync(a => a.ImageId == id) is { } act)
            {
                act.ImageId = null;
                dbContext.Update(act);

                await dbContext.SaveChangesAsync();
            }

            if (await dbContext.People.FirstOrDefaultAsync(a => a.ImageId == id) is { } person)
            {
                person.ImageId = null;
                dbContext.Update(person);

                await dbContext.SaveChangesAsync();
            }

            if (await dbContext.Performances.FirstOrDefaultAsync(a => a.ImageId == id) is { } performance)
            {
                performance.ImageId = null;
                dbContext.Update(performance);

                await dbContext.SaveChangesAsync();
            }

            if (await dbContext.Lineups.FirstOrDefaultAsync(a => a.ImageId == id) is { } lineup)
            {
                lineup.ImageId = null;
                dbContext.Update(lineup);

                await dbContext.SaveChangesAsync();
            }

            dbContext.Images.Remove(image);

            await dbContext.SaveChangesAsync();

            return ((ImageResult?)null).Wrap();
        }

        public async Task<ServiceResult<bool>> Exists(int id)
        {
            return (await dbContext.Images.FindAsync(id) is not null).Wrap();
        }

        public async Task<ServiceResult<ImageResult>> Get(int id)
        {
            return (await dbContext.Images
                .IncludeAll()
                .ToResults()
                .FirstOrDefaultAsync(p => p.Id == id))
                .Wrap(new ServiceMessages().AddNotFound(nameof(Person), id));
        }

        public async Task<PagedServiceResult<IList<ImageResult>, ImageFilterResult>> GetAll(PaginationRequest paginationRequest, ImageFilterRequest filterRequest)
        {
            var totalCount = await dbContext.Images
                .IncludeAll()
                .Filter(filterRequest)
                .CountAsync();

            return (await dbContext.Images
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

        public async Task<ServiceResult<ImageResult>> Update(int id, ImageDbRequest request)
        {
            if (await dbContext.Images.FirstOrDefaultAsync(p => p.Id == id) is not { } image)
            {
                return ((ImageResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), id).AddNotUpdated(nameof(Image), id));
            }

            image.Update(request);

            await dbContext.SaveChangesAsync();

            return image.ToResult().Wrap();
        }
    }
}
