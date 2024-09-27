using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Person
{
    internal static class PersonRequestExtensions
    {
        public static DbCore.Models.Person ToModel(this PersonRequest request)
        {
            var now = DateTime.UtcNow;

            return new DbCore.Models.Person
            {
                Created = now,
                Firstname = request.Firstname,
                ImageId = request.ImageId,
                Lastname = request.Lastname,
                Updated = now,
            };
        }
    }
}