﻿using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Services
{
    public partial class DataController(NavigationManager NavigationManager, MemoryService memoryService, IArtistService artistApiService, IPersonService personApiService)
    {
        public object? Data { get; set; }

        //public bool AppBuildHasFetchError { get; set; }

        public event EventHandler<bool>? OnFetchStateChanged;

        private CancellationTokenSource? _cancellationSource;

        public async Task<bool> HandleLocationChanged(string targetLocation)
        {
            Uri uri;

            var domain = new Uri(NavigationManager.Uri).GetLeftPart(UriPartial.Authority);

            if (!targetLocation.StartsWith(domain))
            {
                uri = new Uri(domain + targetLocation);
            }
            else
            {
                uri = new Uri(targetLocation);
            }

            var route = uri.GetLeftPart(UriPartial.Path).Replace(domain, string.Empty);

            //ARTIST
            if (ArtistIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? MemoryService.DefaultPage,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? MemoryService.DefaultPageSize
                };


                Data = await Fetch<PagedServiceResult<IList<ArtistResult>, ArtistFilter>>(async () => await artistApiService.GetAll(paginationRequest, memoryService.ArtistFilter ?? new ArtistFilter()));

                if (Data is PagedServiceResult<IList<ArtistResult>, ArtistFilter> artistsPagedServiceResult)
                {
                    memoryService.ArtistFilter = artistsPagedServiceResult.Filter;
                    memoryService.ArtistPagination = artistsPagedServiceResult.Pagination;

                    return artistsPagedServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            if (ArtistEditRoute().IsMatch(route))
            {
                Data = await Fetch<ServiceResult<ArtistResult>>(async () => await artistApiService.Get(int.Parse(route.Split('/').Last())));

                if (Data is ServiceResult<ArtistResult> artistServiceResult)
                {
                    return artistServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            //PERSON
            if (PersonIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? MemoryService.DefaultPage,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? MemoryService.DefaultPageSize
                };

                Data = await Fetch<PagedServiceResult<IList<PersonResult>, PersonFilter>>(async () => await personApiService.GetAll(paginationRequest, memoryService.PersonFilter ?? new PersonFilter()));

                if (Data is PagedServiceResult<IList<PersonResult>, PersonFilter> peoplePagedServiceResult)
                {
                    memoryService.PersonFilter = peoplePagedServiceResult.Filter;
                    memoryService.PersonPagination = peoplePagedServiceResult.Pagination;
               
                    return peoplePagedServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            if (PersonEditRoute().IsMatch(route))
            {
                Data = await Fetch<ServiceResult<PersonResult>>(async () => await personApiService.Get(int.Parse(route.Split('/').Last())));

                if (Data is ServiceResult<PersonResult> personServiceResult)
                {
                    return personServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            return true;
        }


        public async Task<TResult> Fetch<TResult>(Func<Task<TResult>> function)
        {
            Data = null;
            _cancellationSource = new CancellationTokenSource();

            OnFetchStateChanged?.Invoke(this, true);

            var task = function();

            var result = await task.WaitAsync(_cancellationSource.Token);

            OnFetchStateChanged?.Invoke(this, false);

            return result;
        }

        //ARTIST
        [GeneratedRegex(@"^/artist/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistEditRoute();

        [GeneratedRegex(@"^/artist$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistIndexRoute();


        //PERSON
        [GeneratedRegex(@"^/person$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex PersonIndexRoute();

        [GeneratedRegex(@"^/person/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex PersonEditRoute();


        public async Task CancelCurrentFetch()
        {
            if (_cancellationSource is not null)
            {
                await _cancellationSource.CancelAsync();
                //_cancellationSource.Dispose();

                OnFetchStateChanged?.Invoke(this, false);
                Data = null;
            }
        }


        public void InvokeOnFetchStateChanged()
        {
            OnFetchStateChanged?.Invoke(this, true);
        }
    }
}
