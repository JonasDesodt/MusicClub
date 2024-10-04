using System.Diagnostics.CodeAnalysis;

namespace MusicClub.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateApiControllers(string models) : Attribute
    {
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "The constructor param is used by source generators")]
        private readonly string _models = models;
    }
}
