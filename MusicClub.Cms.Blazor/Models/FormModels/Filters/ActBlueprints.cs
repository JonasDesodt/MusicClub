using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Act")]
    internal abstract class ActBlueprints : ActFilterRequest, IImageSelect
    {
       public ImageResult? ImageResult { get; set; }
    }
    //public partial class ActFilterFormModel {  }
}
