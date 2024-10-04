using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Requests
{
    [GenerateDataResult]
    public class BandnameRequest
    {
        public required string Name { get; set; }

        public int? ImageId { get; set; }

        public required int BandId { get; set; }
    }
}
