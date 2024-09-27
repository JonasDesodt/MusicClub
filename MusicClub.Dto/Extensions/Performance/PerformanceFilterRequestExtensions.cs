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
                Act = actResult,
                ArtistId = request.ArtistId,
                Artist = artistResult,
                BandnameId = request.BandnameId,
                Bandname = bandnameResult,
                Created = request.Created,
                ImageId = request.ImageId,
                Image = imageResult,
                Instrument = request.Instrument,
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty,
                Updated = request.Updated                          
            };
        }
    }
}