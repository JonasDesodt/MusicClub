using MusicClub.Dto.Enums;
using System.ComponentModel;

namespace MusicClub.Dto.Filters
{
    public class Sort
    {
        public string? SortProperty { get; set; }

        [DefaultValue(SortDirection.Ascending)]
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
