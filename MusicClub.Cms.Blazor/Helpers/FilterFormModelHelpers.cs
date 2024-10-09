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
}
