using Entities;
using K205Medtech.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Medtech.Areas.admin.Controllers
{
    [Area("admin")]
    public class DiscountController : Controller
    {

        private readonly DiscountServices _services;

        private readonly IWebHostEnvironment _environment;

        public DiscountController(IWebHostEnvironment environment, DiscountServices services)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var discount = _services.GetAll();
            return View(discount);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Discount discount)
        {
            _services.CreateDiscount(discount);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            EditVM editVM = new()
            {
                Discount = _services.GetDiscountById()

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Discount discount, string Title, string DiscountOFF, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditDiscount(discount, Title, DiscountOFF, path);

            }
            else
            {
                _services.EditDiscount(discount, Title, DiscountOFF, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var discountDetail = _services.GetDiscountDetailById(id.Value);
            return View(discountDetail);
        }

        public async Task<IActionResult> Delete(Discount discount)
        {
            _services.DeleteDiscount(discount);
            return RedirectToAction(nameof(Index));
        }


    }
}
