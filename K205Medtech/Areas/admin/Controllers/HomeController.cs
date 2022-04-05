using Microsoft.AspNetCore.Mvc;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
