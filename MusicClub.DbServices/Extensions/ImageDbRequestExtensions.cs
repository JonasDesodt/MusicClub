using MusicClub.DbCore.Models;
using MusicClub.Dto.Requests;


namespace MusicClub.DbServices.Extensions
{
    internal static class ImageDbRequestExtensions
    {
        public static Image? ToModel(this ImageDbRequest request)
        {
            var now = DateTime.UtcNow;

            if(request.Content is not null && request.ContentType is not null)
            {
                return new Image
                {
                    Created = now,
                    Updated = now,
                    Alt = request.Alt,
                    Content = request.Content,
                    ContentType = request.ContentType
                };
            }
            else
            {
                return null;
            }
        }
    }
}
