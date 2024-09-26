using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions
{
    public static class LineupFilterResultExtensions
    {
        public static LineupFilterRequest ToRequest(this LineupFilterResult result)
        {
            return new LineupFilterRequest
            {
               SortProperty = result.SortProperty,
               SortDirection = result.SortDirection,
               Doors = result.Doors,
               ImageId = result.ImageId,
               Title = result.Title                        
            };
        }
    }
}
