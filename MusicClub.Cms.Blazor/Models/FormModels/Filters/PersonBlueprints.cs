using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Person")]
    internal abstract class PersonBlueprints : PersonFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }

    [GenerateFilterFormModelExtensions("Person")]
    internal abstract class PersonFilterFormModelExtensionsBlueprint : PersonFilterRequest;
    public partial class PersonFilterFormModel { }

    [GenerateFilterResultExtensions("Person")]
    internal abstract class PersonFilterResultExtensionsBlueprint : PersonFilterResult;
}
