using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Performance")]
    internal abstract class PerformanceBlueprints : PerformanceFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }

    [GenerateFilterFormModelExtensions("Performance")]
    internal abstract class PerformanceFilterFormModelExtensionsBlueprint : PerformanceFilterRequest;
    public partial class PerformanceFilterFormModel { }

    [GenerateFilterResultExtensions("Performance")]
    internal abstract class PerformanceFilterResultExtensionsBlueprint : PerformanceFilterResult;
}
