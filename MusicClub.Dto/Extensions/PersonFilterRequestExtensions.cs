using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;

namespace MusicClub.Dto.Extensions
{
    public static class PersonFilterRequestExtensions
    {
        public static PersonFilterResult ToResult(this PersonFilterRequest request)
        {
            return new PersonFilterResult
            {
                Lastname = request.Lastname,
                Firstname = request.Firstname,
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty
            };
        }
    }
}
