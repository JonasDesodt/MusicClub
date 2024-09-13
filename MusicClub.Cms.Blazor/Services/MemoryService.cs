using MusicClub.Dto.Filters;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Services
{
    public class MemoryService
    {
        public PaginationResult? ArtistPagination { get; set; }

        public ArtistFilter? ArtistFilter { get; set; }

        public void DisposeArtistData()
        {
            ArtistPagination = null;
            ArtistFilter = null;

            HasUnsavedData = false;
        }


        public bool HasUnsavedData { get; set; } = false;
    }
}
