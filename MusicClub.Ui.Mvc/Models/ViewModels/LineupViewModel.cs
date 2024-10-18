using MusicClub.Dto.Results;
using MusicClub.Ui.Mvc.Models.UiModels;

namespace MusicClub.Ui.Mvc.Models.ViewModels
{
    public class LineupViewModel
    {
        public required int Id { get; set; }

        public string? Title { get; set; }
        public required DateTime Doors { get; set; }
        public ImageResult? ImageResult { get; set; }

        public IList<ActUiModel>? ActUiModels { get; set; }
        public required int ActResultsTotalCount { get; set; }
    }
}