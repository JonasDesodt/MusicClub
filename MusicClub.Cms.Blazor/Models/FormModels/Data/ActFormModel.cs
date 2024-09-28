using MusicClub.Cms.Blazor.Interfaces;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Results;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    public class ActFormModel : IImageSelect
    {
        [Required]
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        public int? Duration { get; set; }

        [Required]
        [Min(1)]
        public int? LineupId { get; set; }
        public LineupResult? LineupResult { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
}
