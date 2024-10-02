using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Extensions.Performance
{
    public static class PerformanceFilterRequestExtensions
    {
        public static PerformanceFilterResult ToResult(this PerformanceFilterRequest request, ActResult? actResult = null, ArtistResult? artistResult = null, BandnameResult? bandnameResult = null, ImageResult? imageResult = null)
        {
            return new PerformanceFilterResult
            {
                ActId = request.ActId,
                ActResult = actResult,
                ArtistId = request.ArtistId,
                ArtistResult = artistResult,
                BandnameId = request.BandnameId,
                BandnameResult = bandnameResult,
                Created = request.Created,
                ImageId = request.ImageId,
                ImageResult = imageResult,
                Instrument = request.Instrument,
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty,
                Updated = request.Updated                          
            };
        }
    }
}