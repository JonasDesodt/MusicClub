using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Filters.Extensions;
using MusicClub.Dto.Transfer;
using System.Net.Http;
using System.Net.Http.Json;

namespace MusicClub.ApiServices.Extensions
{
    internal static class HttpClientFactoryExtensions
    {
        public static async Task<ServiceResult<TDataResult>> Create<TDataRequest, TDataResult>(this IHttpClientFactory httpClientFactory, string client, string endpoint, TDataRequest dataRequest)
        {
            var httpClient = httpClientFactory.CreateClient(client);

            var httpResponseMessage = await httpClient.PostAsJsonAsync(endpoint, dataRequest);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<TDataResult>>() is not { } serviceResult)
            {
                return new ServiceResult<TDataResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Fetch error." }],
                };
            }

            return serviceResult;
        }

        public static async Task<ServiceResult<TDataResult>> Delete<TDataResult>(this IHttpClientFactory httpClientFactory, string client, string endpoint, int id)
        {
            var httpClient = httpClientFactory.CreateClient(client);

            var httpResponseMessage = await httpClient.DeleteAsync(endpoint + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<TDataResult>>() is not { } serviceResult)
            {
                return new ServiceResult<TDataResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = $"Failed to fetch the {typeof(TDataResult)}" }],
                };
            }

            return serviceResult;
        }

        public static async Task<ServiceResult<TDataResult>> Get<TDataResult>(this IHttpClientFactory httpClientFactory, string client, string endpoint, int id)
        {
            var httpClient = httpClientFactory.CreateClient(client);

            var httpResponseMessage = await httpClient.GetAsync(endpoint + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<TDataResult>>() is not { } serviceResult)
            {
                return new ServiceResult<TDataResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = $"Failed to fetch the {typeof(TDataResult)}." }],
                };
            }

            return serviceResult;
        }

        public static async Task<PagedServiceResult<IList<TDataResult>, TFilterResult>> GetAll<TDataResult, TFilterRequest, TFilterResult>(this IHttpClientFactory httpClientFactory, string client, string endpoint, PaginationRequest paginationRequest, TFilterRequest filterRequest) where TFilterRequest : IFilterRequestConverter<TFilterResult>
        {
            var httpClient = httpClientFactory.CreateClient(client);

            var httpResponseMessage = await httpClient.GetAsync(endpoint + paginationRequest.ToQueryString() + filterRequest.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<TDataResult>, TFilterResult>>() is not { } pagedServiceResult)
            {
                return new PagedServiceResult<IList<TDataResult>, TFilterResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = $"Failed to fetch the {typeof(TDataResult)}s." }],
                    Pagination = paginationRequest.ToResult(0),
                    Filter = filterRequest.ToResult()
                };
            }

            return pagedServiceResult;
        }

        public static async Task<ServiceResult<TDataResult>> Update<TDataRequest, TDataResult>(this IHttpClientFactory httpClientFactory, string client, string endpoint, int id, TDataRequest request)
        {
            var httpClient = httpClientFactory.CreateClient(client);

            var httpResponseMessage = await httpClient.PutAsJsonAsync(endpoint + id, request);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<TDataResult>>() is not { } serviceResult)
            {
                return new ServiceResult<TDataResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = $"Failed to update the {typeof(TDataRequest)}." }],
                };
            }

            return serviceResult;
        }
    }
}