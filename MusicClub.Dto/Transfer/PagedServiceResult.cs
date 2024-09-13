namespace MusicClub.Dto.Transfer
{
    public class PagedServiceResult<T> : ServiceResult<T>
    {
        public required int Page { get; set; }

        public required int PageSize { get; set; }

        public required int TotalCount { get; set; }

        public required object Filter { get; set; }
    }
}