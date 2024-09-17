using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Services
{
    public class MemoryService
    {
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 24;

        public PaginationResult? ArtistPagination { get; set; }

        public required ArtistFilter ArtistFilter { get; set; } = new ArtistFilter();

        public void DisposeArtistData() 
        {
            ArtistPagination = null;
            ArtistFilter = new ArtistFilter();

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
