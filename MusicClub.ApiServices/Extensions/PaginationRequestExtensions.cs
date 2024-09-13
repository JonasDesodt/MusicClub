using MusicClub.Dto.Transfer;

namespace MusicClub.ApiServices.Extensions
{
    internal static class PaginationRequestExtensions
    {
        public static string ToQueryString(this PaginationRequest paginationRequest)
        {
            return $"page={paginationRequest.Page}&pageSize={paginationRequest.PageSize}";
        }
    }
}