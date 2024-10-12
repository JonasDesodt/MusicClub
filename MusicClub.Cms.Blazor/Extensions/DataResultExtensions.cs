namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ActResultExtensions
    {
        public static bool HasCriticalDependencies(this ActResult result)
        {
            return result.PerformancesCount > 0;
        }
    }
    internal static class ArtistResultExtensions
    {
        public static bool HasCriticalDependencies(this ArtistResult result)
        {
            return result.PerformancesCount > 0;
        }
    }

    internal static class ImageResultExtensions
    {
        public static bool HasCriticalDependencies(this ImageResult _)
        {
            return false;
        }
    }

    internal static class LineupResultExtensions
    {
        public static bool HasCriticalDependencies(this LineupResult result)
        {
            return result.ActsCount > 0 || result.ServicesCount > 0;
        }
    }

    internal static class PerformanceResultExtensions
    {
        public static bool HasCriticalDependencies(this PerformanceResult _)
        {
            return false;
        }
    }

    internal static class PersonResultExtensions
    {
        public static bool HasCriticalDependencies(this PersonResult result)
        {
            return result.ArtistsCount > 0 || result.WorkersCount > 0;
        }
    }

}
