using MusicClub.Cms.Blazor.Models.FormModels.Filters;

namespace MusicClub.Cms.Blazor.Helpers
{
    public interface IFilterResultHelpers<TFilterResult, TFormModel>
    {
        TFormModel ToFormModel(TFilterResult result);
    }

    internal class ActFilterResultHelpers : IFilterResultHelpers<ActFilterResult, ActFilterFormModel>
    {
        public ActFilterFormModel ToFormModel(ActFilterResult result)
        {
            return ActFilterResultExtensions.ToFormModel(result);
        }
    }

    internal class ArtistFilterResultHelpers : IFilterResultHelpers<ArtistFilterResult, ArtistFilterFormModel>
    {
        public ArtistFilterFormModel ToFormModel(ArtistFilterResult result)
        {
            return ArtistFilterResultExtensions.ToFormModel(result);
        }
    }

    internal class ImageFilterResultHelpers : IFilterResultHelpers<ImageFilterResult, ImageFilterFormModel>
    {
        public ImageFilterFormModel ToFormModel(ImageFilterResult result)
        {
            return ImageFilterResultExtensions.ToFormModel(result);
        }
    }

    internal class LineupFilterResultHelpers : IFilterResultHelpers<LineupFilterResult, LineupFilterFormModel>
    {
        public LineupFilterFormModel ToFormModel(LineupFilterResult result)
        {
            return LineupFilterResultExtensions.ToFormModel(result);
        }
    }

    internal class PerformanceFilterResultHelpers : IFilterResultHelpers<PerformanceFilterResult, PerformanceFilterFormModel>
    {
        public PerformanceFilterFormModel ToFormModel(PerformanceFilterResult result)
        {
            return PerformanceFilterResultExtensions.ToFormModel(result);
        }
    }

    internal class PersonFilterResultHelpers : IFilterResultHelpers<PersonFilterResult, PersonFilterFormModel>
    {
        public PersonFilterFormModel ToFormModel(PersonFilterResult result)
        {
            return PersonFilterResultExtensions.ToFormModel(result);
        }
    }
}
