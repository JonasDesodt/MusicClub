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
                ActId = result.ActResult?.Id,
                ActResult = result.ActResult,
                ArtistId = result.ArtistResult?.Id,
                ArtistResult = result.ArtistResult,
                BandnameId = result.BandnameResult?.Id,
                BandnameResult = result.BandnameResult,
                ImageId = result.ImageResult?.Id,
                ImageResult = result.ImageResult,
                Instrument = result.Instrument
            };
        }
    }
}
