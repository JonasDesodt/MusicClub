using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class ActRequest
    {
        [Required]
        public required string Name { get; set; }
        public string? Title { get; set; }

        public DateTime? Start { get; set; }
        public int? Duration { get; set; }

        [Required]
        [Min(1)]
        public required int LineupId { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
    }
}
