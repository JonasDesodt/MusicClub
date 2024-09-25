using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ActFormModelExtensions
    {
        public static ActRequest? ToRequest(this ActFormModel formModel)
        {
            if (formModel.LineupId is not { } lineupId)
            {
                return null;
            }

            if(string.IsNullOrWhiteSpace(formModel.Name))
            {
                return null;
            }

            return new ActRequest
            {
                Duration = formModel.Duration,
                Start = formModel.Start,
                Title = formModel.Title,
                Name = formModel.Name,
                ImageId = formModel.ImageId,
                LineupId = lineupId
            };
        }
    }
}