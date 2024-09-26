using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Artist.Filters
{
    internal static class ArtistFilterResultExtensions
    {
        public static ArtistFilterFormModel ToFormModel(this ArtistFilterResult result)
        {
            return new ArtistFilterFormModel
            {
                Lastname = result.Lastname,
                Firstname = result.Firstname,
                Alias = result.Alias,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty
            };
        }
    }
}