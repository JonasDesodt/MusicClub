using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Person")]
    public abstract class PersonDataFormModelBlueprint : PersonRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class PersonFormModel { }

    [GenerateDataFormModelExtensions("Person")]
    public abstract class PersonDataFormModelExtensionsBlueprint : PersonRequest { }
}