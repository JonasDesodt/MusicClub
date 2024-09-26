using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public class LineupFilterFormModel : Sort
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
