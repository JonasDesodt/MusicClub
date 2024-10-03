using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions.Act.Data
{
    internal static class ActResultExtensions
    {
        public static ActFormModel ToFormModel(this ActResult result)
        {
            return new ActFormModel
            {
                Duration = result.Duration,
                ImageId = result.ImageResult?.Id ?? null,
                ImageResult = result.ImageResult,
                LineupId = result.LineupResult.Id,
                LineupResult = result.LineupResult,
                Name = result.Name,
                Start = result.Start,
                Title = result.Title                      
            };
        }
    }
}