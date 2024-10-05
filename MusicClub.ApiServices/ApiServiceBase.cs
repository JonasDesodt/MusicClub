using MusicClub.Dto.Transfer;
using MusicClub.ApiServices.Extensions;

namespace MusicClub.ApiServices
{
    [GenerateApiServices("Act", "Artist", "Lineup", "Performance", "Person")]
    public abstract class ApiServiceBase<TDataRequest, TDataResult, TFilterRequest, TFilterResult>(IHttpClientFactory httpClientFactory) : IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult>  where TFilterRequest : IFilterRequestConverter<TFilterResult>
    {
        protected abstract string Endpoint { get; }

        public async Task<ServiceResult<TDataResult>> Create(TDataRequest request)
        {
            return await httpClientFactory.Create<TDataRequest, TDataResult>("MusicClubApi", $"{Endpoint}/", request);
        }

        public async Task<ServiceResult<TDataResult>> Delete(int id)
        {
            return await httpClientFactory.Delete<TDataResult>("MusicClubApi", $"{Endpoint}/", id);
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<TDataResult>> Get(int id)
        {
            return await httpClientFactory.Get<TDataResult>("MusicClubApi", $"{Endpoint}/", id);

        }

        public async Task<PagedServiceResult<IList<TDataResult>, TFilterResult>> GetAll(PaginationRequest paginationRequest, TFilterRequest filterRequest)
        {
            return await httpClientFactory.GetAll<TDataResult, TFilterRequest, TFilterResult>("MusicClubApi", $"{Endpoint}?", paginationRequest, filterRequest);

        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<TDataResult>> Update(int id, TDataRequest request)
        {
            return await httpClientFactory.Update<TDataRequest, TDataResult>("MusicClubApi", $"{Endpoint}/", id, request);

        }
    }
}
