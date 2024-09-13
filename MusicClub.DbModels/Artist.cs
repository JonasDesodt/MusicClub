namespace MusicClub.DbCore
{
    public class Artist
    {
        public int Id { get; set; }
        public required int PersonId { get; set; }
        public Person? Person { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public IList<Performance> Performances { get; set; } = [];
    }
}