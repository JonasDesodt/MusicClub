using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class PersonFilterRequest : Sort//, IFilterRequestConverter<PersonFilterResult>
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        //public string ToQueryString()
        //{
        //    return PersonFilterRequestExtensions.ToQueryString(this);
        //}

        //public PersonFilterResult ToResult()
        //{
        //    return PersonFilterRequestExtensions.ToResult(this);
        //}
    }
}
