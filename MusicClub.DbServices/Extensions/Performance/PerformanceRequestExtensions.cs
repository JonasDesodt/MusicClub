using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Performance
{
    internal static class PerformanceRequestExtensions
    {
        public static DbCore.Models.Performance ToModel(this PerformanceRequest request)
        {

            var now = DateTime.UtcNow;

            return new DbCore.Models.Performance
            {
                ActId = request.ActId,
                ArtistId = request.ArtistId,
                Created = now,
                Instrument = request.Instrument,
                Updated = now,
                BandnameId = request.BandnameId,
                ImageId = request.ImageId
            };
        }
    }
}
