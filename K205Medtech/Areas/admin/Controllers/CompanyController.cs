using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class CompanyController : Controller
    {

        private readonly CompanyServices _services;

        private readonly IWebHostEnvironment _environment;

        public CompanyController(IWebHostEnvironment environment, CompanyServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var companies = _services.GetAll();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _services.CreateCompany(company);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                Company = _services.GetCompanyById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company company, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditCompany(company, path);

            }
            else
            {
                _services.EditCompany(company, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var companyDetail = _services.GetCompanyDetailById(id.Value);
            return View(companyDetail);
        }

        public async Task<IActionResult> Delete(Company company)
        {
            _services.DeleteCompany(company);
            return RedirectToAction(nameof(Index));
        }


    }
}
