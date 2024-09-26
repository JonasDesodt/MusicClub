using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Person.Data
{
    internal static class PersonFormModelExtensions
    {
        public static PersonRequest? ToRequest(this PersonFormModel formModel)
        {
            if (string.IsNullOrWhiteSpace(formModel.Firstname) || string.IsNullOrWhiteSpace(formModel.Lastname))
            {
                return null;
            }

            return new PersonRequest
            {
                ImageId = formModel.ImageId,
                Firstname = formModel.Firstname,
                Lastname = formModel.Lastname
            };
        }
    }
}
