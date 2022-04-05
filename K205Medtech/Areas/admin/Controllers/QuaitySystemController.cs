using DataAccess.Migrations;
using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class QualitySystemController : Controller
    {

        private readonly QualitySystemServices _services;

        private readonly IWebHostEnvironment _environment;


        public QualitySystemController(QualitySystemServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var qualitysystem = _services.GetAll();
            return View(qualitysystem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QualitySystem qualitysystem)
        {
            _services.CreateQualitySystem(qualitysystem);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                QualitySystem = _services.GetQualitySystemById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QualitySystem qualitysystem, string Title, string Description, string Service, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditQualitySystem(qualitysystem, Title, Description, Service, path);

            }
            else
            {
                _services.EditQualitySystem(qualitysystem, Title, Description, Service, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var qualitysystemDetail = _services.GetQualitySystemDetailById(id.Value);
            return View(qualitysystemDetail);
        }

        public async Task<IActionResult> Delete(QualitySystem qualitysystem)
        {
            _services.DeleteQualitySystem(qualitysystem);
            return RedirectToAction(nameof(Index));
        }


    }
}
