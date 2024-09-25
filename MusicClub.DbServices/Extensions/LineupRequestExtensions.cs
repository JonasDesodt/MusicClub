using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions
{
    internal static class LineupRequestExtensions
    {
        public static Lineup ToModel(this LineupRequest request)
        {
            var now = DateTime.UtcNow;

            return new Lineup
            {
                Created = now,
                Updated = now,
                ImageId = request.ImageId,
                Doors = request.Doors,
                Title = request.Title                
            };
        }
    }
}
