namespace MusicClub.DbCore.Models
{
    public class Job
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }

        public required int WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public required int FunctionId { get; set; }
        public Function? Function { get; set; }

        public required int ActId { get; set; }
        public Act? Act { get; set; }
    }
}