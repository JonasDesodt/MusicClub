using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    internal static class LineupFilterRequestExtensions
    {


        public static LineupFilterRequest GetCopy(this LineupFilterRequest lineupFilter)
        {
            return new LineupFilterRequest
            {
                Title = lineupFilter.Title,
                Doors = lineupFilter.Doors,
                ImageId = lineupFilter.ImageId,
                SortProperty = lineupFilter.SortProperty,
                SortDirection = lineupFilter.SortDirection
            };
        }
    }
}
