using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Performance.Filters
{
    internal static class PerformanceFilterFormModelExtensions
    {
        public static PerformanceFilterRequest ToRequest(this PerformanceFilterFormModel formModel)
        {
            return new PerformanceFilterRequest
            {
                ActId = formModel.ActId,
                ArtistId = formModel.ArtistId,  
                BandnameId = formModel.BandnameId,
                Created = formModel.Created,
                ImageId = formModel.ImageId,    
                Instrument = formModel.Instrument,
                Updated = formModel.Updated,
                SortProperty = formModel.SortProperty,
                SortDirection = formModel.SortDirection,
            };
        }
    }
}