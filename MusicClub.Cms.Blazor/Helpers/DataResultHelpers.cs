using MusicClub.Cms.Blazor.Extensions;

namespace MusicClub.Cms.Blazor.Helpers
{
    public interface IDataResultHelpers<TDataResult>
    {
        bool HasCriticalDependencies(TDataResult result);
    }

    public class ActDataResultHelpers : IDataResultHelpers<ActResult>
    {
        public bool HasCriticalDependencies(ActResult result)
        {
            return result.HasCriticalDependencies();
        }
    }

    public class ArtistDataResultHelpers : IDataResultHelpers<ArtistResult>
    {
        public bool HasCriticalDependencies(ArtistResult result)
        {
            return result.HasCriticalDependencies();
        }
    }

    public class ImageDataResultHelpers : IDataResultHelpers<ImageResult>
    {
        public bool HasCriticalDependencies(ImageResult result)
        {
            return result.HasCriticalDependencies();
        }
    }

    public class LineupDataResultHelpers : IDataResultHelpers<LineupResult>
    {
        public bool HasCriticalDependencies(LineupResult result)
        {
            return result.HasCriticalDependencies();
        }
    }

    public class PerformanceDataResultHelpers : IDataResultHelpers<PerformanceResult>
    {
        public bool HasCriticalDependencies(PerformanceResult result)
        {
            return result.HasCriticalDependencies();
        }
    }

    public class PersonDataResultHelpers : IDataResultHelpers<PersonResult>
    {
        public bool HasCriticalDependencies(PersonResult result)
        {
            return result.HasCriticalDependencies();
        }
    }
}
