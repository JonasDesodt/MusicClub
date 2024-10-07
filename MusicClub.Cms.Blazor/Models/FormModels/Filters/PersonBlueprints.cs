using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Person")]
    internal abstract class PersonBlueprints : PersonFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class PersonFilterFormModel { }
}
