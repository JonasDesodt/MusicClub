using MusicClub.Dto.Results;

namespace MusicClub.Ui.Mvc.Models.UiModels
{
    public class ActUiModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }
        public System.DateTime? Start { get; set; }
        public int? Duration { get; set; }
        public ImageResult? ImageResult { get; set; }

        public IList<PerformanceResult>? PerformanceResults { get; set; }
        public required int PerformanceResultsTotalCount { get; set; }
    }
}
