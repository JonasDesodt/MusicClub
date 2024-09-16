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
    public class ArtistApiService(IHttpClientFactory httpClientFactory) : IArtistService
    {
        public async Task<ServiceResult<ArtistResult>> Create(ArtistRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PostAsJsonAsync("Artist/", request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ArtistResult>>() is not { } result)
            {
                return new ServiceResult<ArtistResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Fetch error." }],
                };
            }

            return result;
        }

        public async Task<ServiceResult<ArtistResult>> Delete(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.DeleteAsync("Artist/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ArtistResult>>() is not { } result)
            {
                return new ServiceResult<ArtistResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Artist." }],
                };
            }

            return result;
        }

        public Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ArtistResult>> Get(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Artist/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ArtistResult>>() is not { } result)
            {
                return new ServiceResult<ArtistResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Artist." }],
                };
            }

            return result;
        }

        public async Task<PagedServiceResult<IList<ArtistResult>>> GetAll(PaginationRequest paginationRequest, ArtistFilter filter)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Artist?" + paginationRequest.ToQueryString() + filter.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<ArtistResult>>>() is not { } result)
            {
                return new PagedServiceResult<IList<ArtistResult>>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Artists." }],
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

        public async Task<ServiceResult<ArtistResult>> Update(int id, ArtistRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PutAsJsonAsync("Artist/" + id, request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ArtistResult>>() is not { } result)
            {
                return new ServiceResult<ArtistResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to update the artist." }],
                };
            }

            return result;
        }
    }
}
