using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Transfer;
using MusicClub.Ui.Mvc.Models;
using System.Diagnostics;

namespace MusicClub.Ui.Mvc.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ILineupService lineupService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await lineupService.GetAll(new PaginationRequest { Page = 1, PageSize = 12 }, new LineupFilterRequest { }));
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
