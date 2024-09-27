using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions.Person
{
    public static class PersonFilterResultExtensions
    {
        public static PersonFilterRequest ToRequest(this PersonFilterResult result)
        {
            return new PersonFilterRequest
            {
                SortDirection = result.SortDirection,
                SortProperty = result.SortProperty,
                Lastname = result.Lastname,
                Firstname = result.Firstname
            };
        }
    }
}
