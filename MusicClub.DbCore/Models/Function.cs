namespace MusicClub.DbCore.Models
{
    public class Function
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public IList<Job> Jobs { get; set; } = [];

        public IList<Service> Services { get; set; } = [];
    }

    //public enum Function {
    //    Bar,
    //    BuildUp,
    //    CleanUp,
    //    Entrance,
    //    Lightning,
    //    Other
    //    Sound
    //}
}
