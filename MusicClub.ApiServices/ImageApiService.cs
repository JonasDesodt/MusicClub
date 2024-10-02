﻿using MusicClub.ApiServices.Extensions;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Extensions;
using MusicClub.Dto.Filters.Extensions;
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
            return await httpClientFactory.Create<ImageApiRequest, ImageResult>("MusicClubApi", "Image/", request);
        }

        public async Task<ServiceResult<ImageResult>> Delete(int id)
        {
            return await httpClientFactory.Delete<ImageResult>("MusicClubApi", "Image/", id);
        }

        public async Task<ServiceResult<bool>> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ImageResult>> Get(int id)
        {
            return await httpClientFactory.Get<ImageResult>("MusicClubApi", "Image/", id);
        }

        public async Task<PagedServiceResult<IList<ImageResult>, ImageFilterResult>> GetAll(PaginationRequest paginationRequest, ImageFilterRequest filterRequest)
        {
            return await httpClientFactory.GetAll<ImageResult, ImageFilterRequest, ImageFilterResult>("MusicClubApi", "Image?", paginationRequest, filterRequest);
        }

        public Task<ServiceResult<bool>> IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<ImageResult>> Update(int id, ImageApiRequest request)
        {
            return await httpClientFactory.Update<ImageApiRequest, ImageResult>("MusicClubApi", "Image/", id, request);
        }
    }
}
