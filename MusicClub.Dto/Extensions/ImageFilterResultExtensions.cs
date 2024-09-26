using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions
{
   public static  class ImageFilterResultExtensions
    {
        public static ImageFilterRequest ToRequest(this ImageFilterResult result)
        {
            return new ImageFilterRequest
            {
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty,
                Alt = result.Alt                
            };
        }
    }
}
