using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions
{
    internal static class ArtistRequestExtensions
    {
        public static Artist ToModel(this ArtistRequest request)
        {
            var now = DateTime.UtcNow;

            return new Artist
            {
                Created = now,
                Updated = now,
                ImageId = request.ImageId,
                PersonId = request.PersonId,
                Alias = request.Alias
            };
        }
    }
}
