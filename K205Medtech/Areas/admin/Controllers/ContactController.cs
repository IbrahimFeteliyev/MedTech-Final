using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    public class ContactController : Controller
    {


        private readonly ContactServices _services;

        private readonly IWebHostEnvironment _environment;

        public ContactController(IWebHostEnvironment environment, ContactServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var contact = _services.GetAll();
            return View(contact);
        }

    }
}
