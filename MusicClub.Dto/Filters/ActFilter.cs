using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Filters
{
    public class ActFilter : Sort
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        [Min(0)]
        public int? Duration { get; set; }

        [Min(1)]
        public int? LineupId { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
    }
}
