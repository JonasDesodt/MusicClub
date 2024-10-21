using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
    public class GoogleEventRequest
    {
        //[Required]
        //public required string GoogleIdentifier { get; set; }

        [Required]
        [Min(1)]
        public required int GoogleCalendarId { get; set; }

        [Required]
        [Min(1)]
        public required int ActId { get; set; }
    }
}
