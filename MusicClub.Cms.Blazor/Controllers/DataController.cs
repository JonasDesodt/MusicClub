using Microsoft.AspNetCore.Components;
using MusicClub.ApiServices;
using MusicClub.Cms.Blazor.Attributes;
using MusicClub.Cms.Blazor.Helpers;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using System.Diagnostics.CodeAnalysis;

namespace MusicClub.Cms.Blazor.Controllers
{
    [GeneratedDataController]
    public partial class DataController(NavigationManager navigationManager, MemoryService memoryService, IActService actApiService, IArtistService artistApiService, IPersonService personApiService, IPerformanceService performanceApiService, IImageApiService imageApiService, ILineupService lineupApiService) : DataControllerBase(navigationManager, memoryService)
    {
        [PreFetch("Act")]
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "Used by generated code")]
        private readonly IActService _actApiService = actApiService;

        [PreFetch("Artist")]
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "Used by generated code")]
        private readonly IArtistService _artistApiService = artistApiService;

        [PreFetch("Image")]
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "Used by generated code")]
        private readonly IImageApiService _imageApiService = imageApiService;

        [PreFetch("Lineup")]
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "Used by generated code")]
        private readonly ILineupService _lineupApiService = lineupApiService;

        [PreFetch("Performance")]
        private readonly IPerformanceService _performanceApiService = performanceApiService;

        [PreFetch("Person")]
        [SuppressMessage("Style", "IDE0052:Remove unread private member", Justification = "Used by generated code")]
        private readonly IPersonService _personApiService = personApiService;

        protected override partial Task<bool> HandleRoute(string route);

        protected override async Task<bool> HandleCustomRoute(string route)
        {
            if (route == "/")
            {
                Data = await Fetch(async () => await _performanceApiService.GetAll(new PaginationRequest { Page = 1, PageSize = 5, }, new PerformanceFilterRequest { SortDirection = Dto.Enums.SortDirection.Ascending, SortProperty = "Start" }));

                if (Data is PagedServiceResult<IList<PerformanceResult>, PerformanceFilterResult> pagedServiceResult)
                {
                    return pagedServiceResult.Messages?.HasMessage is not true;
                }

                return false;
            }

            return await base.HandleCustomRoute(route);
        }
    }
}
