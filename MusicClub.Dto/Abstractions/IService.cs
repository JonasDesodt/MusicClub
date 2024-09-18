using MusicClub.Dto.Transfer;

namespace MusicClub.Dto.Abstractions
{
    public interface IService
    {
        Task<ServiceResult<bool>> IsReferenced(int id);

        Task<ServiceResult<bool>> Exists(int id);
    }

    public interface IService<TRequest, TResult, TFilter> : IService
    {
        Task<ServiceResult<TResult>> Create(TRequest request);

        Task<ServiceResult<TResult>> Get(int id);

        Task<PagedServiceResult<IList<TResult>, TFilter>> GetAll(PaginationRequest paginationRequest, TFilter filter);

        Task<ServiceResult<TResult>> Delete(int id);

        Task<ServiceResult<TResult>> Update(int id, TRequest request);
    }
}