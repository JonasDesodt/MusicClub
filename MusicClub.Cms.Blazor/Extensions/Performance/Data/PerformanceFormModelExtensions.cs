using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Performance.Data
{
    internal static class PerformanceFormModelExtensions
    {
        public static PerformanceRequest? ToRequest(this PerformanceFormModel formModel)
        {
            if (formModel.ActId is not { } actId)
            {
                return null;
            }

            if (formModel.ArtistId is not { } artistId)
            {
                return null;
            }

            if (formModel.Instrument is not { Length: > 0 } instrument)
            {
                return null;
            }

            return new PerformanceRequest
            {
                ActId = actId,
                ArtistId = artistId,
                BandnameId = formModel.BandnameId,
                Instrument = instrument,
                ImageId = formModel.ImageId
            };
        }
    }
}
