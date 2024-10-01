using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ImageFilterRequest : Sort
    {
        public string? Alt { get; set; }
    }
}
