using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions.Image.Data
{
    internal static partial class ImageResultExtensions
    {
        public static ImageEditDataFormModel ToEditFormModel(this ImageResult result)
        {
            return new ImageEditDataFormModel
            {
                Alt = result.Alt,
            };
        }
    }
}

