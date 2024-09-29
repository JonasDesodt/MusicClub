using MusicClub.Dto.Transfer;

namespace MusicClub.Dto.Abstractions
{
    public interface IService
    {
        Task<ServiceResult<bool>> IsReferenced(int id);

        Task<ServiceResult<bool>> Exists(int id);
    }

    public interface IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> : IService
    {
        Task<ServiceResult<TDataResult>> Create(TDataRequest request);

        Task<ServiceResult<TDataResult>> Get(int id);

        Task<PagedServiceResult<IList<TDataResult>, TFilterResult>> GetAll(PaginationRequest paginationRequest, TFilterRequest filterRequest);

        Task<ServiceResult<TDataResult>> Delete(int id);

        Task<ServiceResult<TDataResult>> Update(int id, TDataRequest request);
    }
}