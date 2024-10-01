using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class PersonFilterRequest : Sort
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
