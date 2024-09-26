using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Image.Filters
{
    internal static class ImageFilterFormModelExtensions
    {
        public static ImageFilterRequest ToRequest(this ImageFilterFormModel formModel)
        {
            return new ImageFilterRequest
            {
                Alt = formModel.Alt,
                SortDirection = formModel.SortDirection,
                SortProperty = formModel.SortProperty
            };
        }
    }
}
