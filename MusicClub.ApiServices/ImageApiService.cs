﻿using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Net.Http.Json;

namespace MusicClub.ApiServices
{
    public class ImageApiService(IHttpClientFactory httpClientFactory) : IImageService
    {
        public Task<ServiceResult<ImageResult>> Create(ImageRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ImageResult>> Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task<PagedServiceResult<IList<ImageResult>>> GetAll(PaginationRequest paginationRequest, ImageFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ImageResult>> Update(int id, ImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}