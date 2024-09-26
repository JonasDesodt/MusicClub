using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public class ArtistFilterFormModel : Sort
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
