using MusicClub.Dto.Filters.Results;
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

        public PaginationResult? ActPagination { get; set; }
        public required ActFilterResult ActFilter { get; set; } = new ActFilterResult();
        public void DisposeActData()
        {
            ActPagination = null;
            ActFilter = new ActFilterResult();

            HasUnsavedData = false;
        }


        public PaginationResult? ArtistPagination { get; set; }
        public required ArtistFilterResult ArtistFilter { get; set; } = new ArtistFilterResult();
        public void DisposeArtistData()
        {
            ArtistPagination = null;
            ArtistFilter = new ArtistFilterResult();

            HasUnsavedData = false;
        }


        public PaginationResult? ImagePagination { get; set; }
        public required ImageFilterResult ImageFilter { get; set; } = new ImageFilterResult();
        public void DisposeImageData()
        {
            ImagePagination = null;
            ImageFilter = new ImageFilterResult();

            HasUnsavedData = false;
        }

        public PaginationResult? LineupPagination { get; set; }
        public required LineupFilterResult LineupFilter { get; set; } = new LineupFilterResult();
        public void DisposeLineupData()
        {
            LineupPagination = null;
            LineupFilter = new LineupFilterResult();

            HasUnsavedData = false;
        }


        public PaginationResult? PerformancePagination { get; set; }
        public required PerformanceFilterResult PerformanceFilter { get; set; } = new PerformanceFilterResult();
        public void DisposePerformanceData()
        {
            PerformancePagination = null;
            PerformanceFilter = new PerformanceFilterResult();

            HasUnsavedData = false;
        }


        public PaginationResult? PersonPagination { get; set; }
        public required PersonFilterResult PersonFilter { get; set; } = new PersonFilterResult();
        public void DisposePersonData()
        {
            PersonPagination = null;
            PersonFilter = new PersonFilterResult();

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
