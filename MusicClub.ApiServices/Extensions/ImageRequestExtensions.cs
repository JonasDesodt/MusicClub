using MusicClub.Dto.Requests;
namespace MusicClub.ApiServices.Extensions
{
    internal static class ImageRequestExtensions
    {
        public static MultipartFormDataContent ToMultipartFormDataContent(this ImageApiRequest request)
        {
            var content = new MultipartFormDataContent();
 
            if (request.File is {  Size: > 0} file)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "File", file.Name);
            }

            content.Add(new StringContent(request.Alt), "Alt");
            //content.Add(new StringContent(file.ContentType), "ContentType");

            return content;
        }
    }
}
