using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace MusicClub.Dto.Requests
{
    public class ImageApiRequest
    {
        [Required]
        public required string Alt { get; set; }

        [Required]
        public required IBrowserFile File { get; set; }
    }
}
