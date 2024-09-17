using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Models.Args
{
    public class PageChangedArgs<TFilter>
    {
        public required PaginationRequest PaginationRequest { get; set; }

        public required TFilter Filter { get; set; }
    }
}
