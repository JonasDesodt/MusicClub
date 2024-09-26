using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions.Artist.Data
{
    internal static class ArtistFormModelExtensions
    {
        public static ArtistRequest? ToRequest(this ArtistFormModel formModel)
        {
            if (formModel.PersonId is not { } personId)
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
