using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Extensions
{
    public static class LineupFilterRequestExtensions
    {
        public static LineupFilterResult ToResult(this LineupFilterRequest filterRequest, ImageResult? imageResult = null)
        {
            return new LineupFilterResult
            {
                SortProperty = filterRequest.SortProperty,
                SortDirection = filterRequest.SortDirection,
                Title = filterRequest.Title,
                Doors = filterRequest.Doors,
                ImageId = filterRequest.ImageId,
                ImageResult = imageResult
            };
        }
    }
}
