using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
    public class GoogleCalendarRequest
    {
        [Required]
        public required string GoogleIdentifier { get; set; }
    }
}
