using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Act;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Filters.Results
{
    public partial class ActFilterResult : Sort, IConvertToRequest<ActFilterRequest>
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public DateTime? Start { get; set; }

        public int? Duration { get; set; }

        public int? LineupId { get; set; }
        public LineupResult? Lineup { get; set; }

        public int? ImageId { get; set; }
        public ImageResult? Image { get; set; }

        public ActFilterRequest ToRequest()
        {
            return ActFilterResultExtensions.ToRequest(this);
        }
    }
}
