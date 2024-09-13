namespace MusicClub.Dto.Results
{
    public class PersonResult
    {
        public required int Id { get; set; }

        public required string Firstname { get; set; }
        public required string Lastname { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public ImageResult? Image { get; set; }

        public required int ArtistsCount { get; set; }
        public required int WorkersCount { get; set; }
        public required int ApplicationUsersCount { get; set; }
    }
}
