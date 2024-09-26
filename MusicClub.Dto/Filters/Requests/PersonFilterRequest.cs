namespace MusicClub.Dto.Filters.Requests
{
    public class PersonFilterRequest : Sort
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
