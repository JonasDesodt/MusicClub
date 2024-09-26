using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public class ActFilterFormModel : Sort
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
        public ImageResult? Image { get; set; }
    }
}
