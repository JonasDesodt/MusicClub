using Microsoft.AspNetCore.Components.Forms;

namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class PerformanceFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(this PerformanceFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Instrument is { } alias && alias.Count() > 0)
            {

                tags.Add(alias, (value) => formModel.Instrument = value);
            }

            if (formModel.ImageId is { } id && id > 0)
            {
                tags.Add("image:" + formModel.ImageResult?.Alt ?? id.ToString(), (value) => formModel.ImageId = null); //todo, convert value to null int?
            }


            return tags;
        }

    }
}
