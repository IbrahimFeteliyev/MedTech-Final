using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class PatientsSayController : Controller
    {

        private readonly PatientsSayServices _services;

        private readonly IWebHostEnvironment _environment;

        public PatientsSayController(IWebHostEnvironment environment, PatientsSayServices services)
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
        public IActionResult Create(PatientsSay about)
        {
            _services.CreatePatientsSay(about);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                PatientsSay = _services.GetPatientsSayById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientsSay patientssay, string PatientName, string Patient, string Description, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditPatientsSay(patientssay, PatientName, Patient, Description, path);

            }
            else
            {
                _services.EditPatientsSay(patientssay, PatientName, Patient, Description, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var patientssayDetail = _services.GetPatientsSayDetailById(id.Value);
            return View(patientssayDetail);
        }

        public async Task<IActionResult> Delete(PatientsSay patientssay)
        {
            _services.DeletePatientsSay(patientssay);
            return RedirectToAction(nameof(Index));
        }


    }
}
