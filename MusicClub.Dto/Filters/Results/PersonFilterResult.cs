using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Extensions.Person;
using MusicClub.Dto.Filters.Requests;

namespace MusicClub.Dto.Filters.Results
{
    public class PersonFilterResult : Sort, IConvertToRequest<PersonFilterRequest>
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public PersonFilterRequest ToRequest()
        {
           return PersonFilterResultExtensions.ToRequest(this);
        }
    }
}