using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class IntroductionController : Controller
    {

        private readonly IntroductionServices _services;

        private readonly IWebHostEnvironment _environment;

        public IntroductionController(IWebHostEnvironment environment, IntroductionServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var introduction = _services.GetAll();
            return View(introduction);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Introduction introduction)
        {
            _services.CreateIntroduction(introduction);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                Introduction = _services.GetIntroductionById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Introduction introduction, string Heading, string Title, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditIntroduction(introduction, Heading, Title, Description, path);

            }
            else
            {
                _services.EditIntroduction(introduction, Heading, Title, Description,  OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var introductionDetail = _services.GetIntroductionDetailById(id.Value);
            return View(introductionDetail);
        }

        public async Task<IActionResult> Delete(Introduction introduction)
        {
            _services.DeleteIntroduction(introduction);
            return RedirectToAction(nameof(Index));
        }


    }
}
