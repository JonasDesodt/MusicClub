using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Act
{
    internal static class ActRequestExtensions
    {
        public static DbCore.Models.Act ToModel(this ActRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.Act
            {
                Created = now,
                Updated = now,
                ImageId = request.ImageId,
                LineupId = request.LineupId,
                Name = request.Name,
                Duration = request.Duration,
                Start = request.Start,
                Title = request.Title
            };
        }
    }
}
