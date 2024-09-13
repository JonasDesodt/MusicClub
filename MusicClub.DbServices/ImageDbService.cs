using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Abstractions;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices
{
    public class ImageDbService(MusicClubDbContext dbContext) : IImageService
    {
        public Task<ServiceResult<ImageResult>> Create(ImageRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ImageResult>> Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task<PagedServiceResult<IList<ImageResult>>> GetAll(PaginationRequest paginationRequest, ImageFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ImageResult>> Update(int id, ImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
