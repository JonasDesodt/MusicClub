using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Lineup.Filters
{
    internal static class LineupFilterFormModelExtensions
    {
        public static LineupFilterRequest ToRequest(this LineupFilterFormModel formModel)
        {
            return new LineupFilterRequest
            {
                SortProperty = formModel.SortProperty,
                SortDirection = formModel.SortDirection,
                Title = formModel.Title,
                Doors = formModel.Doors,
                ImageId = formModel.ImageId               
            };
        }
    }
}
