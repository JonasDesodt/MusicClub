namespace MusicClub.Cms.Blazor.Contexts
{
    public class DataResultContext<TDataResult> where TDataResult : class
    {
        public required TDataResult DataResult { get; set; }

        public bool ShowImages { get; set; } = true;
    }
}
