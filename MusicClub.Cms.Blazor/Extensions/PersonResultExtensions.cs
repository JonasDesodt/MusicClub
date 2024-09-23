using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class PersonResultExtensions
    {
        public static PersonFormModel ToFormModel(this PersonResult result)
        {
            return new PersonFormModel
            {
                ImageId = result.Image?.Id,
                ImageResult = result.Image,
                Firstname = result.Firstname,
                Lastname = result.Lastname
            };
        }
    }
}
