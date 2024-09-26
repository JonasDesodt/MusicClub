using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions
{
    public static class ActFilterResultExtensions
    {
        public static ActFilterRequest ToRequest(this ActFilterResult result)
        {
            return new ActFilterRequest
            {
                ImageId = result.ImageId,
                Title = result.Title,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty,
                Start = result.Start,
                Duration = result.Duration,
                LineupId = result.LineupId,
                Name = result.Name                      
            };
        }

    }
}
