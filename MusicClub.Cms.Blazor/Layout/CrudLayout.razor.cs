using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Layout
{
    [GenerateLayouts("Act", "Artist", "Band", "Image", "Lineup", "Performance", "Person")]

    public abstract partial class CrudLayout
    {
        protected abstract string Model { get; }
    }
}
