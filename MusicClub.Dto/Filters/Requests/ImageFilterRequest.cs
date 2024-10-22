using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ImageFilterRequest : Sort//, IFilterRequestConverter<ImageFilterResult>
    {
        public string? Alt { get; set; }

        //public string ToQueryString()
        //{
        //    return ImageFilterRequestExtensions.ToQueryString(this);
        //}

        //public ImageFilterResult ToResult()
        //{
        //    return ImageFilterRequestExtensions.ToResult(this);
        //}
    }
}
