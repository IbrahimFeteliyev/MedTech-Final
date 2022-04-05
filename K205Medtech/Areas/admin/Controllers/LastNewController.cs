using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class LastNewController : Controller
    {

        private readonly LastNewServices _services;

        private readonly IWebHostEnvironment _environment;

        public LastNewController(IWebHostEnvironment environment, LastNewServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var lastnews = _services.GetAll();
            return View(lastnews);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LastNew lastnew)
        {
            _services.CreateLastNew(lastnew);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                LastNew = _services.GetLastNewById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LastNew lastnew, string Name, string Title, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditLastNew(lastnew, Name, Title, Description, path);

            }
            else
            {
                _services.EditLastNew(lastnew, Name, Title, Description, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var lastnewDetail = _services.GetLastNewDetailById(id.Value);
            return View(lastnewDetail);
        }

        public async Task<IActionResult> Delete(LastNew lastnew)
        {
            _services.DeleteLastNew(lastnew);
            return RedirectToAction(nameof(Index));
        }


    }
}
