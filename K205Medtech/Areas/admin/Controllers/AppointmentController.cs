using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    public class AppointmentController : Controller
    {


            private readonly AppointmentServices _services;

            private readonly IWebHostEnvironment _environment;

            public AppointmentController(IWebHostEnvironment environment, AppointmentServices services)
            {
                _environment = environment;
                _services = services;
            }

            public IActionResult Index()
            {
                var appointment = _services.GetAll();
                return View(appointment);
            }






        
    }
}
