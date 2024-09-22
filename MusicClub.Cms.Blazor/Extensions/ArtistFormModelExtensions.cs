using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ArtistFormModelExtensions
    {
        public static ArtistRequest? ToRequest(this ArtistFormModel formModel)
        {
            if(formModel.PersonId is not { } personId)
            {
                return null;
            }

            return new ArtistRequest
            {
                Alias = formModel.Alias,
                ImageId = formModel.ImageId,
                PersonId = personId
            };
        }
    }
}
