using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Lineup;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Filters.Results
{
   public class LineupFilterResult : Sort, IConvertToRequest<LineupFilterRequest>
    {
        public string? Title { get; set; }

        public DateTime? Doors { get; set; }

        public int? ImageId { get; set; }
        public ImageResult? ImageResult { get; set; }

        public LineupFilterRequest ToRequest()
        {
            return LineupFilterResultExtensions.ToRequest(this);
        }
    }
}
