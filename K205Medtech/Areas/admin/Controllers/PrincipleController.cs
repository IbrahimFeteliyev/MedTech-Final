using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class PrincipleController : Controller
    {

        private readonly PrincipleServices _services;

        private readonly IWebHostEnvironment _environment;

        public PrincipleController(IWebHostEnvironment environment, PrincipleServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var principle = _services.GetAll();
            return View(principle);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Principle principle)
        {
            _services.CreatePrinciple(principle);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                Principle = _services.GetPrincipleById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Principle principle, string Title, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditPrinciple(principle, Title, Description, path);

            }
            else
            {
                _services.EditPrinciple(principle, Title, Description, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var principleDetail = _services.GetPrincipleDetailById(id.Value);
            return View(principleDetail);
        }

        public async Task<IActionResult> Delete(Principle principle)
        {
            _services.DeletePrinciple(principle);
            return RedirectToAction(nameof(Index));
        }



    }
}
