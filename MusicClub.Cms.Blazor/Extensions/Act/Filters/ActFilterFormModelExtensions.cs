using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Act.Filters
{
    internal static class ActFilterFormModelExtensions
    {
        public static ActFilterRequest ToRequest(this ActFilterFormModel formModel)
        {
            return new ActFilterRequest
            {
                Duration = formModel.Duration,
                ImageId = formModel.ImageId,
                LineupId = formModel.LineupId,
                Name = formModel.Name,
                SortDirection = formModel.SortDirection,
                SortProperty = formModel.SortProperty
            };
        }
    }
}
