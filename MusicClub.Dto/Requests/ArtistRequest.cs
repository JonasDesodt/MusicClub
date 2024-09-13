using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class ArtistRequest
    {
        public string? Alias { get; set; }

        [Required]
        [Min(1)]
        public required int PersonId { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
    }
}
