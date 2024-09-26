using MusicClub.Dto.Extensions;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices.Extensions
{
    internal static class PagedServiceResultExtensions
    {
        public static PagedServiceResult<IList<TDataResult>, TFilterResult> Wrap<TDataResult, TFilterResult>(this IList<TDataResult>? data, PaginationRequest paginationRequest, int totalCount,TFilterResult filter, ServiceMessages? messages = null) 
        {
            return new PagedServiceResult<IList<TDataResult>, TFilterResult>
            {
                Data = data,
                Messages = data == null ? messages : null,
                Pagination = paginationRequest.ToResult(totalCount),
                Filter = filter
            };
        }
    }
}