using MusicClub.Dto.Transfer;

namespace MusicClub.DbServices.Extensions
{
    internal static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> query, PaginationRequest paginationRequest)
        {           
            return query.Skip((paginationRequest.Page - 1) * paginationRequest.PageSize).Take(paginationRequest.PageSize);
        } 
    }
}