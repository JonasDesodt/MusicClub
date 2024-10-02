using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;

namespace MusicClub.ApiServices
{
    public class PersonApiService(IHttpClientFactory httpClientFactory) : IPersonService
    {
        public async Task<ServiceResult<PersonResult>> Create(PersonRequest request)
        {
            return await httpClientFactory.Create<PersonRequest, PersonResult>("MusicClubApi", "Person/", request);
        }

        public async Task<ServiceResult<PersonResult>> Delete(int id)
        {
            return await httpClientFactory.Delete<PersonResult>("MusicClubApi", "Person/", id);
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<PersonResult>> Get(int id)
        {
            return await httpClientFactory.Get<PersonResult>("MusicClubApi", "Person/", id);
        }

        public async Task<PagedServiceResult<IList<PersonResult>, PersonFilterResult>> GetAll(PaginationRequest paginationRequest, PersonFilterRequest filterRequest)
        {
            return await httpClientFactory.GetAll<PersonResult, PersonFilterRequest, PersonFilterResult>("MusicClubApi", "Person?", paginationRequest, filterRequest);
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
        {
            return await httpClientFactory.Update<PersonRequest, PersonResult>("MusicClubApi", "Person/", id, request);
        }
    }
}
