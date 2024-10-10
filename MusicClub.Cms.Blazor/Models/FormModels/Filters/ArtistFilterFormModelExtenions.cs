namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class ArtistFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(this ArtistFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Alias is { Length : > 0 } alias)
            {

                tags.Add(alias, (value) => formModel.Alias = value);
            }

            if (formModel.Firstname is { Length : > 0 } firstname)
            {
                tags.Add(firstname, (value) => formModel.Firstname = value);

            }

            if (formModel.Lastname is { Length: > 0 } lastname)
            {
                tags.Add(lastname, (value) => formModel.Lastname = value);
            }

            if (formModel.ImageId is { } id && id > 0)
            {
                tags.Add("image:" + formModel.ImageResult?.Alt ?? id.ToString(), (value) => formModel.ImageId = null); //todo, convert value to null int?
            }

            return tags;
        }

    }
}
