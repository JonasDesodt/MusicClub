using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class LineupRequest
    {
        public string? Title { get; set; }

        [Required]
        public required DateTime Doors { get; set; }

        public int? ImageId { get; set; }
    }
}
