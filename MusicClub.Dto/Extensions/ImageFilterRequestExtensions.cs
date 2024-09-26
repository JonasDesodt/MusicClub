using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions
{
    public static class ImageFilterRequestExtensions
    {
        public static ImageFilterResult ToResult(this ImageFilterRequest request)
        {
            return new ImageFilterResult
            {
                Alt = request.Alt,
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty,
            };
        }
    }
}
