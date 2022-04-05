using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class MobileAppController : Controller
    {

        private readonly MobileAppServices _services;

        private readonly IWebHostEnvironment _environment;

        public MobileAppController(IWebHostEnvironment environment, MobileAppServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var mobileapp = _services.GetAll();
            return View(mobileapp);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MobileApp mobileapp)
        {
            _services.CreateMobileApp(mobileapp);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                MobileApp = _services.GetMobileAppById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MobileApp mobileapp, string Title, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditMobileApp(mobileapp, Title, Description, path);

            }
            else
            {
                _services.EditMobileApp(mobileapp,  Title, Description, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var mobileappDetail = _services.GetMobileAppDetailById(id.Value);
            return View(mobileappDetail);
        }

        public async Task<IActionResult> Delete(MobileApp mobileapp)
        {
            _services.DeleteMobileApp(mobileapp);
            return RedirectToAction(nameof(Index));
        }


    }
}
