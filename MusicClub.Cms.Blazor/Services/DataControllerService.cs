using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Services
{
    public partial class DataControllerService(NavigationManager NavigationManager, MemoryService memoryService, IArtistService artistApiService)
    {
        public object? Data { get; set; }

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

            if (ArtistIndexRoute().IsMatch(route))
            {
                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? 1,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? 2
                };

                Data = await Fetch(async () => await artistApiService.GetAll(paginationRequest, memoryService.ArtistFilter ?? new ArtistFilter()));

                return;
            }

            if (ArtistEditRoute().IsMatch(route))
            {
                Data = await Fetch(async () => await artistApiService.Get(int.Parse(route.Split('/').Last())));

                return;
            }
        }

        public event EventHandler<bool>? OnFetchStateChanged;

        [GeneratedRegex(@"^/artist/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistEditRoute();

        [GeneratedRegex(@"^/artist$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistIndexRoute();

        public async Task<TResult> Fetch<TResult>(Func<Task<TResult>> function)
        {
            Data = null;

            OnFetchStateChanged?.Invoke(this, true);

            var data = await function();

            OnFetchStateChanged?.Invoke(this, false);

            return data;
        }
    }
}
