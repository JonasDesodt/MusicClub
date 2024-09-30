using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Image;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Dto.Filters.Results
{
    public class ImageFilterResult : Sort, IConvertToRequest<ImageFilterRequest>
    {
        public string? Alt { get; set; }

        public ImageFilterRequest ToRequest()
        {
            return ImageFilterResultExtensions.ToRequest(this);
        }
    }
}