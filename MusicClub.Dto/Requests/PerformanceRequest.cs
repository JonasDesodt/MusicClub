using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class PerformanceRequest
    {
        public required string Instrument { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        [Required]
        [Min(1)]
        public required int ArtistId { get; set; }

        [Required]
        [Min(1)]
        public required int ActId { get; set; }

        [Required]
        [Min(1)]
        public int? BandnameId { get; set; }
    }
}
