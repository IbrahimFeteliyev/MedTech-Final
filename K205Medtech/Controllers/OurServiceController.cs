using DataAccess;
using Entities;
using K205Medtech.Models;
using K205Medtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Medtech.Controllers
{
    public class OurServiceController : Controller
    {
        private readonly ILogger<OurServiceController> _logger;
        private readonly MedtechDbContext _context;
        private readonly SendEmailServices _sendEmailServices;
        private readonly PrincipleServices _principleServices;
        private readonly CompanyServices _companyServices;




        public OurServiceController(ILogger<OurServiceController> logger, MedtechDbContext context, SendEmailServices sendEmailServices, PrincipleServices principleServices, CompanyServices companyServices)
        {
            _logger = logger;
            _context = context;
            _sendEmailServices = sendEmailServices;
            _principleServices = principleServices;
            _companyServices = companyServices;
        }

        public IActionResult OurService()
        {
            OurServiceVM ourserviceVM = new()
            {

                Companies = _companyServices.GetAll(),
                Principles = _principleServices.GetAll(),
            };
            return View(ourserviceVM);
        }
        [HttpPost]
        public IActionResult OurService(SendEmail sendemail)
        {

            if (sendemail.Email != null)
            {
                _sendEmailServices.Post(sendemail);
            }

            return RedirectToAction(nameof(OurService));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
