using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Act")]
    public abstract class ActDataFormModelBlueprint : ActRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class ActFormModel { }

    [GenerateDataFormModelExtensions("Act")]
    public abstract class ActDataFormModelExtensionsBlueprint : ActRequest { }

    [GenerateDataResultExtensions("Act")]
    public abstract class ActDataResultBlueprint : ActResult { }
}
