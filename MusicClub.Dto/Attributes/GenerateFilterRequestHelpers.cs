using System.Diagnostics.CodeAnalysis;

namespace MusicClub.Dto.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class GenerateFilterRequestHelpers(params string[] models) : Attribute
    {
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "The constructor param is used by source generators")]
        private readonly string[] _models = models;
    }
}
