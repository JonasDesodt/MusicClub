namespace MusicClub.Dto.Transfer
{
    public class PaginationResult 
    {
        public required int Page { get; set; }

        public required int PageSize { get; set; }

        public required int TotalCount { get; set; }
    }
}