using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Act.Filters
{
    internal static class ActFilterResultExtensions
    {
        public static ActFilterFormModel ToFormModel(this ActFilterResult result)
        {
            return new ActFilterFormModel
            {
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty,
                Name = result.Name,
                LineupId = result.LineupId,
                ImageId = result.ImageId,
                Duration = result.Duration,
                ImageResult = result.ImageResult,
                LineupResult = result.LineupResult,
                Start = result.Start,
                Title = result.Title
            };
        }
    }
}
