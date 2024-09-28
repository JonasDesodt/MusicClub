using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Extensions.Act;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Net.Http.Json;

namespace MusicClub.ApiServices
{
    public class ActApiService(IHttpClientFactory httpClientFactory) : IActService
    {
        public async Task<ServiceResult<ActResult>> Create(ActRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PostAsJsonAsync("Act/", request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ActResult>>() is not { } result)
            {
                return new ServiceResult<ActResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Fetch error." }],
                };
            }

            return result;
        }

        public async Task<ServiceResult<ActResult>> Delete(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.DeleteAsync("Act/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ActResult>>() is not { } result)
            {
                return new ServiceResult<ActResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Act." }],
                };
            }

            return result;
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ActResult>> Get(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Act/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ActResult>>() is not { } result)
            {
                return new ServiceResult<ActResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Act." }],
                };
            }

            return result;
        }

        public async Task<PagedServiceResult<IList<ActResult>, ActFilterResult>> GetAll(PaginationRequest paginationRequest, ActFilterRequest filterRequest)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Act?" + paginationRequest.ToQueryString() + filterRequest.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<ActResult>, ActFilterResult>>() is not { } result)
            {
                return new PagedServiceResult<IList<ActResult>, ActFilterResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Acts." }],
                    Pagination = paginationRequest.ToResult(0),
                    Filter = filterRequest.ToResult()
                };
            }

            return result;
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ActResult>> Update(int id, ActRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PutAsJsonAsync("Act/" + id, request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ActResult>>() is not { } result)
            {
                return new ServiceResult<ActResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to update the act." }],
                };
            }

            return result;
        }
    }
}
