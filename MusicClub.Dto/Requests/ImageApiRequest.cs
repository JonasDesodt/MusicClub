using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Requests
{
    public class ImageApiRequest
    {
        [Required] // todo: test
        public required string Alt { get; set; }

        [Required] // todo: test
        [MaxFileSize] // todo: test
        public required IBrowserFile? File { get; set; }
    }
}
