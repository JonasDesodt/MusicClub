using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Bandname")]
    public abstract class BandnameDataFormModelBlueprint : BandnameRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class BandnameFormModel { }

    [GenerateDataFormModelExtensions("Bandname")]
    public abstract class BandnameDataFormModelExtensionsBlueprint : BandnameRequest { }

    [GenerateDataResultExtensions("Bandname")]
    public abstract class BandnameDataResultBlueprint : BandnameResult { }
}