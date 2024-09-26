using MusicClub.Cms.Blazor.Models.FormModels.Filters;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Cms.Blazor.Extensions.Person.Filters
{
    internal static class PersonFilterResultExtensions
    {
        public static PersonFilterFormModel ToFormModel(this PersonFilterResult result)
        {
            return new PersonFilterFormModel
            {
                Lastname = result.Lastname,
                Firstname = result.Firstname,
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty
            };
        }
    }
}