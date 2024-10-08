using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Performance.Filters
{
    internal static class PerformanceFilterResultExtensions
    {
        public static PerformanceFilterFormModel ToFormModel(this PerformanceFilterResult result)
        {
            return new PerformanceFilterFormModel
            {
                Updated = result.Updated,
                Created = result.Created,
                ActId = result.ActId,
                ActResult = result.ActResult,
                ArtistId = result.ArtistId,
                ArtistResult = result.ArtistResult,
                BandnameId = result.BandnameId,
                BandnameResult = result.BandnameResult,
                ImageId = result.ImageId,   
                ImageResult = result.ImageResult,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty
            };
        }
    }
}