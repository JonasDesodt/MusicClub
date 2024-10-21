using MusicClub.Dto.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
    public class ActRequest
    {
        [Required]
        public required string Name { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Start { get; set; }
        public int? Duration { get; set; }

        [Required]
        [Min(1)]
        public required int LineupId { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }


        public int? GoogleEventDbIdentity { get; set; } //try to get rid of this, only here because the UI needs it from the ActResult, only adding it to the static ActResult partial makes the generators create mapping to formmodel,but does not create a prop for it in the formmodel
    }
}
