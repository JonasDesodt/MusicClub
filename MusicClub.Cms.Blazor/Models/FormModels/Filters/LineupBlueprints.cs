using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Lineup")]
    internal abstract class LineupBlueprints : LineupFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }

    [GenerateFilterFormModelExtensions("Lineup")]
    internal abstract class LineupFilterFormModelExtensionsBlueprint : LineupFilterRequest;
    public partial class LineupFilterFormModel { }

    [GenerateFilterResultExtensions("Lineup")]
    internal abstract class LineupFilterResultExtensionsBlueprint : LineupFilterResult;
}
