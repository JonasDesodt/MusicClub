using Microsoft.EntityFrameworkCore;
using MusicClub.Dto.Abstractions;
using MusicClub.DbCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.IO;

namespace MusicClub.DbServices
{
    public class ImageDbService(MusicClubDbContext dbContext) : IImageDbService
    {
        public async Task<ServiceResult<ImageResult>> Create(ImageDbRequest request)
        {
            var image = request.ToModel();

            await dbContext.Images.AddAsync(image);

            await dbContext.SaveChangesAsync();

            return await Get(image.Id);
        }




        //if (request.BrowserFile is not { } file || file.Length == 0)
        //{
        //    return ((ImageResult?)null).Wrap(new ServiceMessages().AddNotCreated(nameof(Image)).AddNotCreated(nameof(Image)));
        //}

        //var now = DateTime.UtcNow;

        //using (var memoryStream = new MemoryStream())
        //{
        //    await file.CopyToAsync(memoryStream);

        //    // Upload the file if less than 2 MB
        //    if (memoryStream.Length < 2097152)
        //    {
        //        var image = new Image
        //        {
        //            Alt = request.Alt,
        //            Created = now,
        //            Updated = now,
        //            Content = memoryStream.ToArray(),
        //            ContentType = file.ContentType
        //        };

        //        dbContext.Images.Add(image);

        //        await dbContext.SaveChangesAsync();

        //        return await Get(image.Id);
        //    }
        //}
    


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

        public async Task<PagedServiceResult<IList<ImageResult>, ImageFilter>> GetAll(PaginationRequest paginationRequest, ImageFilter filter)
        {
            var totalCount = await dbContext.Images
                .IncludeAll()
                .Filter(filter)
                .CountAsync();

            return (await dbContext.Images
                .IncludeAll()
                .Filter(filter)
                .GetPage(paginationRequest)
                .ToResults()
                .ToListAsync())
                .Wrap(paginationRequest, totalCount, filter);
        }

        public async Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ImageResult>> Update(int id, ImageDbRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
