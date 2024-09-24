using Microsoft.AspNetCore.Components.Forms;

namespace MusicClub.Cms.Blazor.Abstractions
{
    public interface IImageFormModel
    {
        string? Alt { get; set; }

        IBrowserFile? BrowserFile { get; set; }
    }
}
