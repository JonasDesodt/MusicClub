using MusicClub.Cms.Blazor.Models.FormModels.Data;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions.Artist.Data
{
    internal static class ArtistResultExtensions
    {
        public static ArtistFormModel ToFormModel(this ArtistResult result)
        {
            return new ArtistFormModel
            {
                ImageId = result.ImageResult?.Id,
                ImageResult = result.ImageResult,
                PersonId = result.PersonResult?.Id,
                PersonResult = result.PersonResult,
                Alias = result.Alias
            };
        }
    }
}
