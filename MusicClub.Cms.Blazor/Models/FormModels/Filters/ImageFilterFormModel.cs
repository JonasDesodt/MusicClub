using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;
using MusicClub.Cms.Blazor.Interfaces;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    internal class ImageFilterFormModel : Sort, IImageSelect
    {
        public string? Alt { get; set; }
        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
