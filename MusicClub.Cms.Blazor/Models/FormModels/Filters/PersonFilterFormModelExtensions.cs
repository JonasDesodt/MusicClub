namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class PersonFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(PersonFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Firstname is { } firstname && firstname.Count() > 0)
            {
                tags.Add(firstname, (value) => formModel.Firstname = value);

            }

            if (formModel.Lastname is { } lastname && lastname.Count() > 0)
            {
                tags.Add(lastname, (value) => formModel.Lastname = value);
            }

            return tags;
        }
    }
}
