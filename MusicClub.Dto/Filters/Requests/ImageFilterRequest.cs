using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ImageFilterRequest : Sort, IFilterRequestConverter<ImageFilterResult>
    {
        public string? Alt { get; set; }

        public string ToQueryString()
        {
            return "";
        }

        public ImageFilterResult ToResult()
        {
            return ImageFilterRequestExtensions.ToResult(this);
        }
    }
}
