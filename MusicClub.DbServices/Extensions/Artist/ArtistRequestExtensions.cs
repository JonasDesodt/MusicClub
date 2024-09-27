using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Artist
{
    internal static class ArtistRequestExtensions
    {
        public static DbCore.Models.Artist ToModel(this ArtistRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.Artist
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
