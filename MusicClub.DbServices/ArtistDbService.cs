using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices
{
    public class ArtistDbService(MusicClubDbContext dbContext) : IArtistService
    {
        public async Task<ServiceResult<ArtistResult>> Create(ArtistRequest request)
        {
            if (!await dbContext.People.ExistsOrIsNull(request.PersonId))
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Person), request.PersonId).AddNotCreated(nameof(Artist)));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotCreated(nameof(Artist)));
            }

            var artist = request.ToModel();

            await dbContext.Artists.AddAsync(artist);

            await dbContext.SaveChangesAsync();

            return await Get(artist.Id);
        }

        public async Task<ServiceResult<ArtistResult>> Delete(int id)
        {
            if (await dbContext.Artists.FindAsync(id) is not { } artist)
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Artist), id).AddNotDeleted(nameof(Artist), id));
            }

            if (await dbContext.Performances.HasReferenceToArtist(id))
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddReferenceFound(nameof(Artist), id, nameof(Performance)).AddNotDeleted(nameof(Artist), id));
            }

            dbContext.Artists.Remove(artist);

            await dbContext.SaveChangesAsync();

            return ((ArtistResult?)null).Wrap();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ArtistResult>> Get(int id)
        {
            return (await dbContext.Artists
                    .IncludeAll()
                    .ToResults()
                    .FirstOrDefaultAsync(p => p.Id == id))
                    .Wrap(new ServiceMessages().AddNotFound(nameof(Artist), id));
        }

        public async Task<PagedServiceResult<IList<ArtistResult>>> GetAll(PaginationRequest paginationRequest, ArtistFilter filter)
        {
            var totalCount = await dbContext.Artists
                .IncludeAll()
                .Filter(filter)
                .CountAsync();

            return (await dbContext.Artists
                .IncludeAll()
                .Filter(filter)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filter);
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ArtistResult>> Update(int id, ArtistRequest request)
        {
            if (await dbContext.Artists.IncludeAll().FirstOrDefaultAsync(p => p.Id == id) is not { } artist)
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Artist), id).AddNotUpdated(nameof(Artist), id));
            }

            if (!await dbContext.People.ExistsOrIsNull(request.PersonId))
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Person), request.PersonId).AddNotUpdated(nameof(Artist), id));
            }

            if (!await dbContext.Images.ExistsOrIsNull(request.ImageId))
            {
                return ((ArtistResult?)null).Wrap(new ServiceMessages().AddNotFound(nameof(Image), request.ImageId).AddNotUpdated(nameof(Artist), id));
            }

            artist.Update(request);

            await dbContext.SaveChangesAsync();

            return artist.ToResult().Wrap();
        }
    }
}
