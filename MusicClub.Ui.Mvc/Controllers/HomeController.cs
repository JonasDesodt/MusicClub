using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Transfer;
using MusicClub.Ui.Mvc.Models;
using MusicClub.Ui.Mvc.Models.UiModels;
using System.Diagnostics;

namespace MusicClub.Ui.Mvc.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IActService actService, ILineupService lineupService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (await lineupService.GetAll(new PaginationRequest { Page = 1, PageSize = 12 }, new LineupFilterRequest { }) is { Data: not null, Messages: null } lineupPagedServiceResult)
            {
                var uiPagedServiceResult = new PagedServiceResult<IList<LineupUiModel>, Dto.Filters.Results.LineupFilterResult> { Data = [], Pagination = lineupPagedServiceResult.Pagination, Filter = lineupPagedServiceResult.Filter };

                foreach (var lineupResult in lineupPagedServiceResult.Data)
                {
                    var actPagedServiceResult = await actService.GetAll(new PaginationRequest { Page = 1, PageSize = 5 }, new ActFilterRequest { LineupId = lineupResult.Id });

                    uiPagedServiceResult.Data.Add(new LineupUiModel { Id = lineupResult.Id, Doors = lineupResult.Doors, ImageResult = lineupResult.ImageResult, Title = lineupResult.Title, ActResults = actPagedServiceResult.Data, ActResultsTotalCount = actPagedServiceResult.Pagination.TotalCount });
                }

                return View(uiPagedServiceResult);
            }

            return RedirectToAction("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
