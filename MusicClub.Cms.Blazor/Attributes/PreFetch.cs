namespace MusicClub.Cms.Blazor.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PreFetch(string model) : Attribute { }
}