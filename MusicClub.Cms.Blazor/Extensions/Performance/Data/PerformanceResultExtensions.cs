using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions.Performance.Data
{
    internal static class PerformanceResultExtensions
    {
        public static PerformanceFormModel ToResult(this PerformanceResult result)
        {
            return new PerformanceFormModel
            {
                ActId = result.Act?.Id,
                ActResult = result.Act,
                ArtistId = result.Artist?.Id,
                ArtistResult = result.Artist,
                BandnameId = result.Bandname?.Id,
                BandnameResult = result.Bandname,
                ImageId = result.Image?.Id,
                ImageResult = result.Image,
                Instrument = result.Instrument
            };
        }
    }
}
