using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Interfaces
{
    internal interface IImageSelect
    {
        int? ImageId { get; set; }
        ImageResult? ImageResult { get; set; }
    }
}
