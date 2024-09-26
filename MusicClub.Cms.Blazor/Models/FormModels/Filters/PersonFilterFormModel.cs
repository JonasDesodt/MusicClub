using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public class PersonFilterFormModel : Sort
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
