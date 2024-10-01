using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    public class TestFilterRequest : Sort
    {
        public string? Prop { get; set; }
    }
}
