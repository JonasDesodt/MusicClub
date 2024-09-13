using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class PersonRequest
    {
        [Required]
        public required string Firstname { get; set; }

        [Required]
        public required string Lastname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }
    }
}
