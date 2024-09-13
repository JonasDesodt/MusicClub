namespace MusicClub.DbCore
{
    public class Service
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public required int WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public required int FuntionId { get; set; }
        public Function? Function { get; set; }

        public required int LineupId { get; set; }
        public Lineup? Lineup { get; set; }
    }
}