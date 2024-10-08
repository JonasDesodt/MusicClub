using System.Diagnostics.CodeAnalysis;

namespace MusicClub.Cms.Blazor.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateFilterFormModelExtensions(string model) : Attribute
    {
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "The constructor param is used by source generators")]
        private readonly string _model = model;
    }
}
