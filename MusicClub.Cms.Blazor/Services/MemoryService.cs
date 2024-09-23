using MusicClub.Dto.Filters;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Services
{
    public class MemoryService
    {
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 2;

        public static PaginationRequest GetDefaultPaginationRequest()
        {
            return new PaginationRequest
            {
                Page = DefaultPage,
                PageSize = DefaultPageSize
            };
        }

        public PaginationResult? ArtistPagination { get; set; }
        public required ArtistFilter ArtistFilter { get; set; } = new ArtistFilter();
        public void DisposeArtistData() 
        {
            ArtistPagination = null;
            ArtistFilter = new ArtistFilter();

            HasUnsavedData = false;
        }

        public PaginationResult? PersonPagination { get; set; }
        public required PersonFilter PersonFilter { get; set; } = new PersonFilter();
        public void DisposePersonData()
        {
            PersonPagination = null;
            PersonFilter = new PersonFilter();

            HasUnsavedData = false;
        }


        public bool HasUnsavedData { get; set; } = false;
        public event EventHandler? OnConfirmationRequested;

        public void RequestConfirmation()
        {
            OnConfirmationRequested?.Invoke(this, EventArgs.Empty);
        }

        public string? NavigationRequest { get; set; }       
    }
}
