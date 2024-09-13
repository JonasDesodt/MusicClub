using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Net.Http.Json;

namespace MusicClub.ApiServices
{
    public class PersonApiService(IHttpClientFactory httpClientFactory) : IPersonService
    {
        public Task<ServiceResult<PersonResult>> Create(PersonRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PersonResult>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<PersonResult>> Get(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Person/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<PersonResult>>() is not { } result)
            {
                return new ServiceResult<PersonResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Person." }],
                };
            }

            return result;
        }

        public async Task<PagedServiceResult<IList<PersonResult>>> GetAll(PaginationRequest paginationRequest, PersonFilter filter)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Person?" + paginationRequest.ToQueryString() + filter.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<PersonResult>>>() is not { } result)
            {
                return new PagedServiceResult<IList<PersonResult>>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the People." }],
                    Page = paginationRequest.Page,
                    PageSize = paginationRequest.PageSize,
                    TotalCount = 0,
                    Filter = filter
                };
            }

            return result;
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
