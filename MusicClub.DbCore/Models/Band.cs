namespace MusicClub.DbCore.Models
{
    public class Band
    {
        public int Id { get; set; }


        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public IList<Bandname> Bandnames { get; set; } = [];
    }
}