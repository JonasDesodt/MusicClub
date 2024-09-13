using System.ComponentModel.DataAnnotations;
using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Transfer
{
    public class PaginationRequest
    {
        [Required]
        [Min(1)]
        public required int Page { get; set; }

        [Required]
        [Between(1, 24)]
        public required int PageSize { get; set; }
    }
}