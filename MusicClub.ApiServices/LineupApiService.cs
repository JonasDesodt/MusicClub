using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Extensions.Lineup;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Net.Http.Json;

namespace MusicClub.ApiServices
{
    public class LineupApiService(IHttpClientFactory httpClientFactory) : ILineupService
    {
        public async Task<ServiceResult<LineupResult>> Create(LineupRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PostAsJsonAsync("Lineup/", request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<LineupResult>>() is not { } result)
            {
                return new ServiceResult<LineupResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Fetch error." }],
                };
            }

            return result;
        }

        public async Task<ServiceResult<LineupResult>> Delete(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.DeleteAsync("Lineup/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<LineupResult>>() is not { } result)
            {
                return new ServiceResult<LineupResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Lineup." }],
                };
            }

            return result;
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<LineupResult>> Get(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Lineup/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<LineupResult>>() is not { } result)
            {
                return new ServiceResult<LineupResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Lineup." }],
                };
            }

            return result;
        }

        public async Task<PagedServiceResult<IList<LineupResult>, LineupFilterResult>> GetAll(PaginationRequest paginationRequest, LineupFilterRequest filterRequest)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Lineup?" + paginationRequest.ToQueryString() + filterRequest.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<LineupResult>, LineupFilterResult>>() is not { } result)
            {
                return new PagedServiceResult<IList<LineupResult>, LineupFilterResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Lineups." }],
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

        public async Task<ServiceResult<LineupResult>> Update(int id, LineupRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PutAsJsonAsync("Lineup/" + id, request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<LineupResult>>() is not { } result)
            {
                return new ServiceResult<LineupResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to update the lineup." }],
                };
            }

            return result;
        }
    }
}
