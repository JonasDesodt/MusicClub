namespace MusicClub.Abstractions.DbModels
{
    public interface ITimestamps
    {
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}
