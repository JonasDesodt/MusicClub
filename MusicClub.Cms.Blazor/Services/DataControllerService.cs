using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Extensions;

namespace MusicClub.Cms.Blazor.Services
{
    public partial class DataController(NavigationManager NavigationManager, MemoryService memoryService, IActService actApiService, IArtistService artistApiService, IPersonService personApiService, IImageApiService imageApiService)
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

            //ACT
            if (ActIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ActPagination?.Page ?? MemoryService.DefaultPage,
                    PageSize = memoryService.ActPagination?.PageSize ?? MemoryService.DefaultPageSize
                };

                Data = await Fetch<PagedServiceResult<IList<ActResult>, ActFilterResult>>(async () => await actApiService.GetAll(paginationRequest, memoryService.ActFilter?.ToRequest() ?? new ActFilterRequest()));

                if (Data is PagedServiceResult<IList<ActResult>, ActFilterResult> actsPagedServiceResult)
                {
                    memoryService.ActFilter = actsPagedServiceResult.Filter;
                    memoryService.ActPagination = actsPagedServiceResult.Pagination;

                    return actsPagedServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            if (ActEditRoute().IsMatch(route))
            {
                Data = await Fetch<ServiceResult<ArtistResult>>(async () => await artistApiService.Get(int.Parse(route.Split('/').Last())));

                if (Data is ServiceResult<ArtistResult> artistServiceResult)
                {
                    return artistServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }


            //ARTIST
            if (ArtistIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? MemoryService.DefaultPage,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? MemoryService.DefaultPageSize
                };


                Data = await Fetch<PagedServiceResult<IList<ArtistResult>, ArtistFilterResult>>(async () => await artistApiService.GetAll(paginationRequest, memoryService.ArtistFilter?.ToRequest() ?? new ArtistFilterRequest()));

                if (Data is PagedServiceResult<IList<ArtistResult>, ArtistFilterResult> artistsPagedServiceResult)
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

                Data = await Fetch<PagedServiceResult<IList<PersonResult>, PersonFilterResult>>(async () => await personApiService.GetAll(paginationRequest, memoryService.PersonFilter?.ToRequest() ?? new PersonFilterRequest()));

                if (Data is PagedServiceResult<IList<PersonResult>, PersonFilterResult> peoplePagedServiceResult)
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


            //IMAGE
            if (ImageIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ImagePagination?.Page ?? MemoryService.DefaultPage,
                    PageSize = memoryService.ImagePagination?.PageSize ?? MemoryService.DefaultPageSize
                };

                Data = await Fetch<PagedServiceResult<IList<ImageResult>, ImageFilterResult>>(async () => await imageApiService.GetAll(paginationRequest, memoryService.ImageFilter?.ToRequest() ?? new ImageFilterRequest()));

                if (Data is PagedServiceResult<IList<ImageResult>, ImageFilterResult> imagesPagedServiceResult)
                {
                    memoryService.ImageFilter = imagesPagedServiceResult.Filter;
                    memoryService.ImagePagination = imagesPagedServiceResult.Pagination;

                    return imagesPagedServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            if (ImageEditRoute().IsMatch(route))
            {
                Data = await Fetch<ServiceResult<ImageResult>>(async () => await imageApiService.Get(int.Parse(route.Split('/').Last())));

                if (Data is ServiceResult<ImageResult> imageServiceResult)
                {
                    return imageServiceResult.Messages?.HasMessage is not true;
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

        //ACT
        [GeneratedRegex(@"^/act/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ActEditRoute();

        [GeneratedRegex(@"^/act$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ActIndexRoute();


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


        //IMAGE
        [GeneratedRegex(@"^/image$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ImageIndexRoute();

        [GeneratedRegex(@"^/image/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ImageEditRoute();


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
