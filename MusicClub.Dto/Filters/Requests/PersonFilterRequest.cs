using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class PersonFilterRequest : Sort, IFilterRequestConverter<PersonFilterResult>
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string ToQueryString()
        {
            return "";
        }

        public PersonFilterResult ToResult()
        {
            return PersonFilterRequestExtensions.ToResult(this);
        }
    }
}
