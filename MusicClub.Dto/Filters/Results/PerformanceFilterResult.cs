using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Performance;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Filters.Results
{
    public class PerformanceFilterResult : Sort, IConvertToRequest<PerformanceFilterRequest>
    {
        public string? Instrument { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        public int? ImageId { get; set; }
        public ImageResult? Image { get; set; }

        public int? ArtistId { get; set; }
        public ArtistResult? Artist { get; set; }

        public int? ActId { get; set; }
        public ActResult? Act { get; set; }

        public int? BandnameId { get; set; }
        public BandnameResult? Bandname { get; set; }

        public PerformanceFilterRequest ToRequest()
        {
            return PerformanceFilterResultExtensions.ToRequest(this);
        }
    }
}
