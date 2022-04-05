using DataAccess;
using Entities;
using K205Medtech.Models;
using K205Medtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Medtech.Controllers
{
    public class ContactController : Controller
    {

        private readonly ILogger<ContactController> _logger;
        private readonly MedtechDbContext _context;
        private readonly CompanyServices _companyServices;
        private readonly SendEmailServices _sendEmailServices;
        private readonly ContactServices _contactServices;


        public ContactController(ILogger<ContactController> logger, MedtechDbContext context, CompanyServices companyServices, SendEmailServices sendEmailServices, ContactServices contactServices)
        {
            _logger = logger;
            _context = context;
            _companyServices = companyServices;
            _sendEmailServices = sendEmailServices;
            _contactServices = contactServices;
        }

        public IActionResult Contact()
        {
            HomeVM homeVM = new()
            {
                Companies = _companyServices.GetAll(),
            };
            return View(homeVM);
        }
        [HttpPost]
        public IActionResult Contact(Contact contact, SendEmail sendemail)
        {
            if (contact.Name != null & contact.Email != null & contact.Phone != null & contact.Message != null)
            {

                _contactServices.PostContact(contact);

            }
            else if (sendemail.Email != null)
            {
                _sendEmailServices.Post(sendemail);

            }

            return RedirectToAction(nameof(Contact));
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
