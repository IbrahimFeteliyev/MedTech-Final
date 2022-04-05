using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {

        private readonly ServiceServices _services;

        private readonly IWebHostEnvironment _environment;

        public ServiceController(IWebHostEnvironment environment, ServiceServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var services = _services.GetAll();
            return View(services);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            _services.CreateService(service);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                Service = _services.GetServiceById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Service service, string Name, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditService(service, Name, Description, path);

            }
            else
            {
                _services.EditService(service, Name, Description, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var serviceDetail = _services.GetServiceDetailById(id.Value);
            return View(serviceDetail);
        }

        public async Task<IActionResult> Delete(Service service)
        {
            _services.DeleteService(service);
            return RedirectToAction(nameof(Index));
        }


    }
}
