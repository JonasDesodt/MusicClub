using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices.Extensions
{
    internal static class PagedServiceResultExtensions
    {
        public static PagedServiceResult<IList<T>> Wrap<T>(this IList<T>? data, PaginationRequest paginationRequest, int totalCount, object filter, ServiceMessages? messages = null) 
        {
            return new PagedServiceResult<IList<T>>
            {
                Data = data,
                Messages = data == null ? messages : null,
                Page = paginationRequest.Page,
                PageSize = paginationRequest.PageSize,
                TotalCount = totalCount,
                Filter = filter
            };
        }
    }
}