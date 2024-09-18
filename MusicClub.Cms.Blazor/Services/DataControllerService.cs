using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Services
{
    public partial class DataControllerService(NavigationManager NavigationManager, MemoryService memoryService, IArtistService artistApiService, IPersonService personApiService)
    {
        public object? Data { get; set; }

        public event EventHandler<bool>? OnFetchStateChanged;


        public async Task HandleLocationChanged(string targetLocation)
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
                    Page = memoryService.ArtistPagination?.Page ?? 1,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? 2
                };

                Data = await Fetch<PagedServiceResult<IList<ArtistResult>, ArtistFilter>>(async () => await artistApiService.GetAll(paginationRequest, memoryService.ArtistFilter ?? new ArtistFilter()));

                return;
            }

            if (ArtistEditRoute().IsMatch(route))
            {
                Data = await Fetch<ServiceResult<ArtistResult>>(async () => await artistApiService.Get(int.Parse(route.Split('/').Last())));

                return;
            }

            //PERSON
            if (PersonIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? 1,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? 2
                };

                Data = await Fetch<PagedServiceResult<IList<PersonResult>, PersonFilter>>(async () => await personApiService.GetAll(paginationRequest, memoryService.PersonFilter ?? new PersonFilter()));

                return;
            }

        }


        public async Task<TResult> Fetch<TResult>(Func<Task<TResult>> function)
        {
            Data = null;

            OnFetchStateChanged?.Invoke(this, true);

            var data = await function();

            OnFetchStateChanged?.Invoke(this, false);

            return data;
        }

        
        [GeneratedRegex(@"^/artist/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistEditRoute();

        [GeneratedRegex(@"^/artist$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistIndexRoute();


        [GeneratedRegex(@"^/person$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex PersonIndexRoute();
    }
}
