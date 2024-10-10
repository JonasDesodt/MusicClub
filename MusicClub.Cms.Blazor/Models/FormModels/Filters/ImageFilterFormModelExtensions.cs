namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class ImageFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(ImageFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Alt is { Length : > 0 } alt)
            {

                tags.Add(alt, (value) => formModel.Alt = value);
            }

            return tags;
        }
    }
}