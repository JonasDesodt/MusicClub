using MusicClub.Dto.Results;

namespace MusicClub.Ui.Mvc.Models.UiModels
{
    public class LineupUiModel
    {
        public required int Id { get; set; }

        public string? Title { get; set; }
        public required DateTime Doors { get; set; }
        public ImageResult? ImageResult { get; set; }

        public IList<ActResult>? ActResults { get; set; }
        public required int ActResultsTotalCount { get; set; }
    }
}
