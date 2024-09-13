using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions
{
    internal static class PersonRequestExtensions
    {
        public static Person ToModel(this PersonRequest request)
        {
            var now = DateTime.UtcNow;

            return new Person
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