namespace MusicClub.Dto.Requests
{
    public class ImageDbRequest
    {
        public required string Alt { get; set; }

        public required byte[]? Content { get; set; }

        public required string? ContentType { get; set; }
    }
}
