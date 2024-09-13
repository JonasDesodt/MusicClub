namespace MusicClub.DbCore
{
    public class Image
    {
        public int Id { get; set; }
        public required string Alt { get; set; }
        public required byte[] Content { get; set; }
        public required string ContentType { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }
    }
}