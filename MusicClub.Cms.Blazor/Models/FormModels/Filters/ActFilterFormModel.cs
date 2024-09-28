using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using MusicClub.Dto.Filters;
using MusicClub.Cms.Blazor.Interfaces;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    internal class ActFilterFormModel : Sort, IImageSelect
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        [Min(0)]
        public int? Duration { get; set; }

        [Min(1)]
        public int? LineupId { get; set; }
        public LineupResult? Lineup { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
