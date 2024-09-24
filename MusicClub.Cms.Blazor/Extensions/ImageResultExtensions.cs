using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ImageResultExtensions
    {
        public static ImageEditFormModel ToEditFormModel(this ImageResult result)
        {
            return new ImageEditFormModel
            {
                Alt = result.Alt,
            };
        }
    }
}

