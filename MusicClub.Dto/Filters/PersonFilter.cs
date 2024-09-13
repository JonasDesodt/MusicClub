using MusicClub.Dto.Enums;

namespace MusicClub.Dto.Filters
{
    public class PersonFilter : Sort
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
