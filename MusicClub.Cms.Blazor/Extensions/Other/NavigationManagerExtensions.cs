using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.WebUtilities;
using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Extensions.Other
{

    //https://www.meziantou.net/bind-parameters-from-the-query-string-in-blazor.htm

    internal static class NavigationManagerExtensions
    {
        public static int? GetPage(this NavigationManager navigationManager)
        {
            return QueryHelpers.ParseQuery(navigationManager.GetQueryString()).GetPage();
        }

        public static string GetQueryString(this NavigationManager navigationManager)
        {
            return new Uri(navigationManager.Uri).Query;
        }

        //public static ArtistFilter GetArtistFilter(this NavigationManager navigationManager)
        //{
        //    return QueryHelpers.ParseQuery(navigationManager.GetQueryString()).GetArtistFilter();
        //}
    }
}