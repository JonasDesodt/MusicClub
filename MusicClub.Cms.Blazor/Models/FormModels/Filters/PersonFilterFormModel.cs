using MusicClub.Dto.Filters;
using MusicClub.Cms.Blazor.Interfaces;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    internal class PersonFilterFormModel : Sort, IImageSelect
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
