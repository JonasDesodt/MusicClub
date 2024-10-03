using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
    public class LineupRequest
    {
        public string? Title { get; set; }

        [Required]
        public required DateTime Doors { get; set; }

        public int? ImageId { get; set; }
    }
}
