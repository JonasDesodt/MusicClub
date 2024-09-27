using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Extensions.Image;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Net.Http.Json;

namespace MusicClub.ApiServices
{
    public class ImageApiService(IHttpClientFactory httpClientFactory) : IImageApiService
    {
        public async Task<ServiceResult<ImageResult>> Create(ImageApiRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PostAsync("Image/", request.ToMultipartFormDataContent());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ImageResult>>() is not { } result)
            {
                return new ServiceResult<ImageResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Fetch error." }],
                };
            }

            return result;
        }

        public async Task<ServiceResult<ImageResult>> Delete(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.DeleteAsync("Image/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ImageResult>>() is not { } result)
            {
                return new ServiceResult<ImageResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Image." }],
                };
            }

            return result;
        }

        public async Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();

            //var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            //var httpResponseMessage = await httpClient.GetAsync("Image/Exists/" + id);

            //if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<bool>>() is not { } result)
            //{
            //    return new ServiceResult<bool>
            //    {
            //        Messages = [new ServiceMessage { Description = "Failed to search the Image." }],
            //    };
            //}

            //return result;
        }

        public async Task<ServiceResult<ImageResult>> Get(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Image/" + id);

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ImageResult>>() is not { } result)
            {
                return new ServiceResult<ImageResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Image." }],
                };
            }

            return result;
        }

        public async Task<PagedServiceResult<IList<ImageResult>, ImageFilterResult>> GetAll(PaginationRequest paginationRequest, ImageFilterRequest filterRequest)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.GetAsync("Image?" + paginationRequest.ToQueryString() + filterRequest.ToQueryString());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<PagedServiceResult<IList<ImageResult>, ImageFilterResult>>() is not { } result)
            {
                return new PagedServiceResult<IList<ImageResult>, ImageFilterResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to fetch the Images." }],
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

        public async Task<ServiceResult<ImageResult>> Update(int id, ImageApiRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("MusicClubApi");

            var httpResponseMessage = await httpClient.PutAsync("Image/" + id, request.ToMultipartFormDataContent());

            if (!httpResponseMessage.IsSuccessStatusCode || await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResult<ImageResult>>() is not { } result)
            {
                return new ServiceResult<ImageResult>
                {
                    Messages = [new ServiceMessage { Code = ErrorCode.FetchError, Description = "Failed to update the image." }],
                };
            }

            return result;
        }
    }
}
