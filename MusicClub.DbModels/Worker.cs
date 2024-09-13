namespace MusicClub.DbCore
{
    public class Worker
    {
        public int Id { get; set; }
        public bool IsTechnician { get; set; }
        public bool IsEmployee { get; set; }
                
        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public required int PersonId { get; set; }
        public Person? Person { get; set; }

        public IList<Job> Jobs { get; set; } = [];

        public IList<Service> Services { get; set; } = [];
    }
}