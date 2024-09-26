using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Lineup.Filters
{
    internal static class LineupFilterResultExtensions
    {
        public static LineupFilterFormModel ToFormModel(this LineupFilterResult result)
        {
            return new LineupFilterFormModel
            {
                ImageId = result.ImageId,
                Doors = result.Doors,
                Title = result.Title,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty,
                ImageResult = result.ImageResult                
            };
        }
    }
}
