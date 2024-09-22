using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Results;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ArtistResultExtensions
    {
        public static ArtistFormModel ToFormModel(this ArtistResult result)
        {
            return new ArtistFormModel
            {
                ImageId = result.Image?.Id,
                ImageResult = result.Image,
                PersonId = result.Person?.Id,
                PersonResult = result.Person,
                Alias = result.Alias
            };
        }
    }
}
