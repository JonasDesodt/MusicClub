using MusicClub.Dto.Transfer;

namespace MusicClub.Dto.Extensions
{
    public static class PaginationRequestExtensions
    {
        public static PaginationResult ToResult(this PaginationRequest request, int totalCount)
        {
            return new PaginationResult
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount,
            };
        }
    }
}
