using MusicClub.Cms.Blazor.Models.FormModels.Filters;

namespace MusicClub.Cms.Blazor.Helpers
{
    public interface IFilterFormModelHelpers<TFilterRequest, TFilterFormModel>
    {
        Dictionary<string, Action<string?>>? GetTags(TFilterFormModel model);

        TFilterRequest? ToRequest(TFilterFormModel model);
    }

    public class ActFilterFormModelHelpers : IFilterFormModelHelpers<ActFilterRequest, ActFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(ActFilterFormModel model)
        {
            return ActFilterFormModelExtensions.GetTags(model);
        }

        public ActFilterRequest? ToRequest(ActFilterFormModel model)
        {
            return ActFilterFormModelExtensions.ToRequest(model);
        }
    }

    public class ArtistFilterFormModelHelpers : IFilterFormModelHelpers<ArtistFilterRequest, ArtistFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(ArtistFilterFormModel model)
        {
            return ArtistFilterFormModelExtensions.GetTags(model);
        }

        public ArtistFilterRequest? ToRequest(ArtistFilterFormModel model)
        {
            return ArtistFilterFormModelExtensions.ToRequest(model);
        }
    }

    public class ImageFilterFormModelHelpers : IFilterFormModelHelpers<ImageFilterRequest, ImageFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(ImageFilterFormModel model)
        {
            return ImageFilterFormModelExtensions.GetTags(model);
        }

        public ImageFilterRequest? ToRequest(ImageFilterFormModel model)
        {
            return ImageFilterFormModelExtensions.ToRequest(model);
        }
    }

    public class LineupFilterFormModelHelpers : IFilterFormModelHelpers<LineupFilterRequest, LineupFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(LineupFilterFormModel model)
        {
            return LineupFilterFormModelExtensions.GetTags(model);
        }

        public LineupFilterRequest? ToRequest(LineupFilterFormModel model)
        {
            return LineupFilterFormModelExtensions.ToRequest(model);
        }
    }

    public class PerformanceFilterFormModelHelpers : IFilterFormModelHelpers<PerformanceFilterRequest, PerformanceFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(PerformanceFilterFormModel model)
        {
            return PerformanceFilterFormModelExtensions.GetTags(model);
        }

        public PerformanceFilterRequest? ToRequest(PerformanceFilterFormModel model)
        {
            return PerformanceFilterFormModelExtensions.ToRequest(model);
        }
    }

    public class PersonFilterFormModelHelpers : IFilterFormModelHelpers<PersonFilterRequest, PersonFilterFormModel>
    {
        public Dictionary<string, Action<string?>>? GetTags(PersonFilterFormModel model)
        {
            return PersonFilterFormModelExtensions.GetTags(model);
        }

        public PersonFilterRequest? ToRequest(PersonFilterFormModel model)
        {
            return PersonFilterFormModelExtensions.ToRequest(model);
        }
    }
}