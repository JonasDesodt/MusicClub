using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class ImageFilterRequestExtensions
    {


        public static ImageFilterRequest GetCopy(this ImageFilterRequest imageFilter)
        {
            return new ImageFilterRequest
            {
                Alt = imageFilter.Alt,                
                SortProperty = imageFilter.SortProperty,
                SortDirection = imageFilter.SortDirection
            };
        }
    }
}
