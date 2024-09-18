namespace MusicClub.Dto.Transfer
{
    public class PagedServiceResult<TModel, TFilter> : ServiceResult<TModel>
    {
        public required int Page { get; set; }

        public required int PageSize { get; set; }

        public required int TotalCount { get; set; }

        public required TFilter Filter { get; set; }
    }
}