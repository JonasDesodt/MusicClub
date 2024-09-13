using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Abstractions
{
    public interface IImageService : IService<ImageRequest, ImageResult, ImageFilter> { }
}