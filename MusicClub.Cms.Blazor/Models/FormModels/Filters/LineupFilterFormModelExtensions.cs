namespace MusicClub.Cms.Blazor.Models.FormModels.Filters
{
    public static partial class LineupFilterFormModelExtensions
    {
        public static Dictionary<string, Action<string?>>? GetTags(LineupFilterFormModel formModel)
        {
            var tags = new Dictionary<string, Action<string?>>();

            if (formModel.Title is { } title && title.Count() > 0)
            {
                tags.Add(title, (value) => formModel.Title = value);
            }

            if (formModel.Doors is { } doors)
            {
                tags.Add(doors.ToShortDateString(), (value) => formModel.Doors = null); //todo; temp hack? of change all lamba to set the prop to null, not using the value param?
            }

            return tags;
        }
    }
}