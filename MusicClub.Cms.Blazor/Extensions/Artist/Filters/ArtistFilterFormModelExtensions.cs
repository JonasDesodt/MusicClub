using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Artist.Filters
{
    internal static class ArtistFilterFormModelExtensions
    {
        public static ArtistFilterRequest ToRequest(this ArtistFilterFormModel formModel)
        {
            return new ArtistFilterRequest
            {
                SortProperty = formModel.SortProperty,
                SortDirection = formModel.SortDirection,
                Alias = formModel.Alias,
                Firstname = formModel.Firstname,
                Lastname = formModel.Lastname
            };
        }
    }
}
