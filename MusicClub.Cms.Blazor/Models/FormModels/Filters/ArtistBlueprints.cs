using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Artist")]
    internal abstract class ArtistBlueprints : ArtistFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }

    [GenerateFilterFormModelExtensions("Artist")]
    internal abstract class ArtistFilterFormModelExtensionsBlueprint : ArtistFilterRequest;

    [GenerateFilterResultExtensions("Artist")]
    internal abstract class ArtistFilterResultExtensionsBlueprint : ArtistFilterResult;
}
