using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Extensions.Act
{
    public static class ActFilterRequestExtensions
    {
        public static ActFilterResult ToResult(this ActFilterRequest request, ImageResult? imageResult = null, LineupResult? lineupResult = null)
        {
            return new ActFilterResult
            {
                Duration = request.Duration,
                ImageId = request.ImageId,
                LineupId = request.LineupId,
                Image = imageResult,
                Lineup = lineupResult,
                Name = request.Name,
                Start = request.Start,
                Title = request.Title,
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty,
            };
        }
    }
}