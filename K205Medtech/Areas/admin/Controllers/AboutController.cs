using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {

        private readonly AboutServices _services;

        private readonly IWebHostEnvironment _environment;

        public AboutController(IWebHostEnvironment environment, AboutServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var about = _services.GetAll();
            return View(about);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            _services.CreateAbout(about);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                About = _services.GetAboutById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about, int Count, string Text, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditAbout(about, Count, Text, path);

            }
            else
            {
                _services.EditAbout(about, Count, Text, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var aboutDetail = _services.GetAboutDetailById(id.Value);
            return View(aboutDetail);
        }

        public async Task<IActionResult> Delete(About about)
        {
            _services.DeleteAbout(about);
            return RedirectToAction(nameof(Index));
        }


    }
}
