using MusicClub.Dto.Enums;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ActFilterRequestExtensions
    {


        public static ActFilterRequest GetCopy(this ActFilterRequest actFilter)
        {
            return new ActFilterRequest
            {
                SortProperty = actFilter.SortProperty,
                SortDirection = actFilter.SortDirection,
                Name = actFilter.Name,
                Title = actFilter.Title,
                Duration = actFilter.Duration,
                ImageId = actFilter.ImageId,
                LineupId = actFilter.LineupId,
                Start = actFilter.Start
            };
        }
    }
}
