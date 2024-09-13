using Microsoft.Extensions.Primitives;
using MusicClub.Dto.Filters;

namespace MusicClub.Cms.Blazor.Extensions
{
    public static class DictionaryExtensions
    {
        public static int? GetPage(this Dictionary<string, StringValues> dictionary)
        {
            if (dictionary.TryGetValue("page", out StringValues pageValue) && int.TryParse(pageValue, out int page))
            {
                return page;
            }

            return null;
        }

        public static ArtistFilter GetArtistFilter(this Dictionary<string, StringValues> dictionary)
        {
            var artistFilter = new ArtistFilter();

            if (dictionary.TryGetValue(nameof(ArtistFilter.Alias).ToLower(), out StringValues aliasValue))
            {
                artistFilter.Alias = aliasValue.ToString();
            }

            if (dictionary.TryGetValue(nameof(ArtistFilter.Firstname).ToLower(), out StringValues firstnameValue))
            {
                artistFilter.Firstname = firstnameValue.ToString();
            }

            if (dictionary.TryGetValue(nameof(ArtistFilter.Lastname).ToLower(), out StringValues lastnameValue))
            {
                artistFilter.Firstname = lastnameValue.ToString();
            }

            return artistFilter;
        }
    }
}
