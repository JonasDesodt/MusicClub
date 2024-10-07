using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    [GenerateFilterFormModel("Lineup")]
    internal abstract class LineupBlueprints : LineupFilterRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class LineupFilterFormModel {  } 
}
