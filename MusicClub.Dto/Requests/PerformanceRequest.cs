using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
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

        [Min(1)]
        public int? BandnameId { get; set; }
    }
}
