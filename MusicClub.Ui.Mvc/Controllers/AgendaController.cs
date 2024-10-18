using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Transfer;
using MusicClub.Ui.Mvc.Models.UiModels;
using MusicClub.Ui.Mvc.Models.ViewModels;

namespace MusicClub.Ui.Mvc.Controllers
{
    public class AgendaController(IActService actService, ILineupService lineupService, IPerformanceService performanceService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            if (await lineupService.Get(id) is { Data: not null, Messages: null } lineupServiceResult)
            {
                var lineupViewModel = new LineupViewModel
                {
                    Id = lineupServiceResult.Data.Id,
                    Doors = lineupServiceResult.Data.Doors,
                    ImageResult = lineupServiceResult.Data.ImageResult,
                    Title = lineupServiceResult.Data.Title,
                    ActUiModels = [],
                    ActResultsTotalCount = 0
                };

                if (await actService.GetAll(new PaginationRequest { Page = 1, PageSize = 24 }, new ActFilterRequest { LineupId = lineupServiceResult.Data.Id }) is { Data: not null, Messages: null } actPagedServiceResult)
                {
                    lineupViewModel.ActResultsTotalCount = actPagedServiceResult.Pagination.TotalCount;

                    foreach (var actResult in actPagedServiceResult.Data)
                    {
                        if (await performanceService.GetAll(new PaginationRequest { Page = 1, PageSize = 24 }, new PerformanceFilterRequest { ActId = actResult.Id }) is { Data: not null, Messages: null } performancePagedServiceResult)
                        {
                            lineupViewModel.ActUiModels.Add(new ActUiModel
                            {
                                Id = actResult.Id,
                                Name = actResult.Name,
                                Duration = actResult.Duration,
                                ImageResult = actResult.ImageResult,
                                Start = actResult.Start,
                                Title = actResult.Title,
                                PerformanceResults = performancePagedServiceResult.Data,
                                PerformanceResultsTotalCount = performancePagedServiceResult.Pagination.TotalCount,
                            });
                        }
                    }
                }

                return View(lineupViewModel);
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
