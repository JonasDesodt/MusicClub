using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Artist")]
    internal abstract class ArtistBlueprints : ArtistFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class ArtistFilterFormModel { }
}
