using Microsoft.AspNetCore.Components;
using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Cms.Blazor.Helpers;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Cms.Blazor.Controllers
{
    [GeneratedDataController]
    public partial class DataController(NavigationManager navigationManager, MemoryService memoryService, IActService actApiService, IArtistService artistApiService, IPersonService personApiService, IPerformanceService performanceApiService, IImageApiService imageApiService, ILineupService lineupApiService) : DataControllerBase(navigationManager, memoryService)
    {
        [PreFetch("Act")]
        private readonly IActService _actApiService = actApiService;

        [PreFetch("Artist")]
        private readonly IArtistService _artistApiService = artistApiService;

        [PreFetch("Image")]
        private readonly IImageApiService _imageApiService = imageApiService;

        [PreFetch("Lineup")]
        private readonly ILineupService _lineupApiService = lineupApiService;

        [PreFetch("Performance")]
        private readonly IPerformanceService _performanceApiService = performanceApiService;

        [PreFetch("Person")]
        private readonly IPersonService _personApiService = personApiService;

        protected override partial Task<bool> HandleRoute(string route);
    }
}
