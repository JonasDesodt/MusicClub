using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Performance")]
    public abstract class PerformanceDataFormModelBlueprint : PerformanceRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class PerformanceFormModel { }

    [GenerateDataFormModelExtensions("Performance")]
    public abstract class PerformanceDataFormModelExtensionsBlueprint : PerformanceRequest { }
}
