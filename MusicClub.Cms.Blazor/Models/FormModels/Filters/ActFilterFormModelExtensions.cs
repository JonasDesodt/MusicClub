namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class ActFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(this ActFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Name is { Length : > 0 } alias)
            {
                tags.Add("name: " + alias, (value) => formModel.Name = value);
            }

            if (formModel.ImageId is { } id && id > 0)
            {
                tags.Add("image:" + formModel.ImageResult?.Alt ?? id.ToString(), (value) => formModel.ImageId = null); //todo, convert value to null int?
            }

            return tags;
        }
    }
}
