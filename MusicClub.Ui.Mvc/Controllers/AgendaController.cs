using Microsoft.AspNetCore.Mvc;

namespace MusicClub.Ui.Mvc.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
