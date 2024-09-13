using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;
using MusicClub.Cms.Blazor.Extensions;
using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Filters;

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
                Data = null;

                OnFetchStateChanged?.Invoke(this, true);

                //var parsedQuery = QueryHelpers.ParseQuery(uri.Query);
                //var page = parsedQuery.GetPage();
                //if(page is null)
                //{
                //    page = 1;
                //}

                var paginationRequest = new PaginationRequest
                {
                    Page = memoryService.ArtistPagination?.Page ?? 1,
                    PageSize = memoryService.ArtistPagination?.PageSize ?? 2
                };
                
                Data = await artistApiService.GetAll(paginationRequest, memoryService.ArtistFilter ?? new ArtistFilter { });

                OnFetchStateChanged?.Invoke(this, false);

                return;
            }

            if (ArtistEditRoute().IsMatch(route))
            {
                OnFetchStateChanged?.Invoke(this, true);

                Data = await artistApiService.Get(int.Parse(route.Split('/').Last()));

                OnFetchStateChanged?.Invoke(this, false);

                return;
            }
        }

        public event EventHandler<bool>? OnFetchStateChanged;

        [GeneratedRegex(@"^/artist/edit/\d+$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistEditRoute();

        [GeneratedRegex(@"^/artist$", RegexOptions.IgnoreCase, "nl-AW")]
        private static partial Regex ArtistIndexRoute();
    }
}
