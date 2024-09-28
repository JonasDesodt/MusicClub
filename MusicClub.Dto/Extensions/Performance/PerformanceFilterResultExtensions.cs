using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions.Performance
{
    public static class PerformanceFilterResultExtensions
    {
        public static PerformanceFilterRequest ToRequest(this PerformanceFilterResult result)
        {
            return new PerformanceFilterRequest
            {
                SortProperty = result.SortProperty,
                SortDirection = result.SortDirection,
                ImageId = result.ImageId,
                ActId = result.ActId,
                ArtistId = result.ArtistId,
                BandnameId = result.BandnameId,
                Created = result.Created,
                Instrument = result.Instrument,
                Updated = result.Updated               
            };
        }
    }
}
