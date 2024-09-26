using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Image.Filters
{
    internal static class ImageFilterResultExtensions
    {
        public static ImageFilterFormModel ToFormModel(this ImageFilterResult result)
        {
            return new ImageFilterFormModel
            {
                Alt = result.Alt,
                SortProperty = result.SortProperty,
                SortDirection = result.SortDirection
            };
        }
    }
}
