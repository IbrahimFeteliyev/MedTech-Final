using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProfessionalController : Controller
    {

        private readonly ProfessionalServices _services;

        private readonly IWebHostEnvironment _environment;

        public ProfessionalController(IWebHostEnvironment environment, ProfessionalServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var professional = _services.GetAll();
            return View(professional);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Professional professional)
        {
            _services.CreateProfessional(professional);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                Professional = _services.GetProfessionalById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Professional professional, string Name, string Profession, string Description, string Facebook, string Twitter, string LinkedIn, string Pinterest, string Email, string Phone, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditProfessional(professional, Name, Profession, Description ,Facebook ,Twitter, LinkedIn , Pinterest, Email, Phone, path);

            }
            else
            {
                _services.EditProfessional(professional, Name, Profession, Description, Facebook, Twitter, LinkedIn, Pinterest, Email, Phone, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var professionalDetail = _services.GetProfessionalDetailById(id.Value);
            return View(professionalDetail);
        }

        public async Task<IActionResult> Delete(Professional professional)
        {
            _services.DeleteProfessional(professional);
            return RedirectToAction(nameof(Index));
        }


    }
}
