using MusicClub.Dto.Extensions;
using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices.Extensions
{
    internal static class PagedServiceResultExtensions
    {
        public static PagedServiceResult<IList<TModel>, TFilter> Wrap<TModel, TFilter>(this IList<TModel>? data, PaginationRequest paginationRequest, int totalCount,TFilter filter, ServiceMessages? messages = null) 
        {
            return new PagedServiceResult<IList<TModel>, TFilter>
            {
                Data = data,
                Messages = data == null ? messages : null,
                Pagination = paginationRequest.ToResult(totalCount),
                Filter = filter
            };
        }
    }
}