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
                ImageId = result.Image?.Id ?? null,
                ImageResult = result.Image,
                LineupId = result.Lineup.Id,
                LineupResult = result.Lineup,
                Name = result.Name,
                Start = result.Start,
                Title = result.Title                      
            };
        }
    }
}