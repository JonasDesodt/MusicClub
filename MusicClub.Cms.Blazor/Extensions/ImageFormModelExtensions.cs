using MusicClub.Cms.Blazor.Models.FormModels;
using MusicClub.Dto.Requests;

namespace MusicClub.Cms.Blazor.Extensions
{
    internal static class ImageFormModelExtensions
    {
        public static MultipartFormDataContent? ToMultipartFormDataContent(this ImageFormModel model)
        {
            if (model.BrowserFile is not { Size: > 0 } file)
            {
                return null;
            }

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(file.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            content.Add(fileContent, "file", file.Name);

            content.Add(new StringContent(model.Alt ?? file.Name), "Alt");
            //content.Add(new StringContent(file.ContentType), "ContentType");

            return content;
        }

        public static ImageApiRequest? ToRequest(this ImageFormModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Alt))
            {
                return null;
            }

            return new ImageApiRequest
            {
                Alt = model.Alt,
                File = model.BrowserFile,
            };
        }
    }
}
