using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Artist")]
    public abstract class ArtistDataFormModelBlueprint : ArtistRequest, IImageSelect
    {
        public PersonResult? PersonResult { get; set; }
        public ImageResult? ImageResult { get; set; }
    }
    public partial class ArtistFormModel { }

    [GenerateDataFormModelExtensions("Artist")]
    public abstract class ArtistDataFormModelExtensionsBlueprint : ArtistRequest { }

    [GenerateDataResultExtensions("Artist")]
    public abstract class ArtistDataResultBlueprint : ArtistResult { }
}