using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions.Image.Data
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

