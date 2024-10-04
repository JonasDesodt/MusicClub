using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using System.Text;

namespace MusicClub.ApiServices.Extensions
{
    public static class PersonFilterRequestExtensions
    {
        public static PersonFilterRequest GetCopy(this PersonFilterRequest personFilter)
        {
            return new PersonFilterRequest
            {
                Firstname = personFilter.Firstname,
                Lastname = personFilter.Lastname,
                SortProperty = personFilter.SortProperty,
                SortDirection = personFilter.SortDirection
            };
        }
    }
}