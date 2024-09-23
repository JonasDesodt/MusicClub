using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class PersonFormModelExtensions
    {
        public static PersonRequest? ToRequest(this PersonFormModel formModel)
        {
            if(string.IsNullOrWhiteSpace(formModel.Firstname) || string.IsNullOrWhiteSpace(formModel.Lastname)){
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
