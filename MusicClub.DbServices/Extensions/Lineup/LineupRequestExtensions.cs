using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Lineup
{
    public static class LineupRequestExtensions
    {
        public static DbCore.Models.Lineup ToModel(this LineupRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.Lineup
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
