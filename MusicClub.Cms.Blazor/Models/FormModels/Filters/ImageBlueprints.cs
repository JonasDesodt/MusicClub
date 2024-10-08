using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Image")]
    internal abstract class ImageBlueprints : ImageFilterRequest { }
    public partial class ImageFilterFormModel { }

    [GenerateFilterFormModelExtensions("Image")]
    internal abstract class ImageFilterFormModelExtensionsBlueprint : ImageFilterRequest;

    [GenerateFilterResultExtensions("Image")]
    internal abstract class ImageFilterResultExtensionsBlueprint : ImageFilterResult;
}
