namespace MusicClub.Cms.Blazor.Interfaces
{
    public interface IImageSelect
    {
        int? ImageId { get; set; }
        ImageResult? ImageResult { get; set; }
    }
}
