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
                Act = result.Act,
                ArtistId = result.ArtistId,
                Artist = result.Artist,
                BandnameId = result.BandnameId,
                Bandname = result.Bandname,
                ImageId = result.ImageId,   
                ImageResult = result.Image,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty
            };
        }
    }
}