using MusicClub.Dto.Enums;

namespace MusicClub.Dto.Filters
{
    public class Sort
    {
        public string? SortProperty { get; set; }

        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
