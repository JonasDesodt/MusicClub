using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Person.Filters
{
    internal static class PersonFilterFormModelExtensions
    {
        public static PersonFilterRequest ToRequest(this PersonFilterFormModel formModel)
        {
            return new PersonFilterRequest
            {
                SortProperty = formModel.SortProperty,
                SortDirection = formModel.SortDirection,
                Firstname = formModel.Firstname,
                Lastname = formModel.Lastname
            };
        }
    }
}