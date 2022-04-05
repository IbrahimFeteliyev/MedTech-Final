using DataAccess;
using Entities;
using K205Medtech.Models;
using K205Medtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Medtech.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<AboutUsController> _logger;
        private readonly MedtechDbContext _context;
        private readonly QualitySystemServices _qualitysystemServices;
        private readonly AboutServices _aboutServices;
        private readonly CompanyServices _companyServices;
        private readonly SendEmailServices _sendEmailServices;
        private readonly AppointmentServices _appointmentServices;
        private readonly ProfessionalServices _professionalServices;
        private readonly PrincipleServices _principleServices;


        public AboutUsController(ILogger<AboutUsController> logger, MedtechDbContext context, QualitySystemServices qualitysystemServices, AboutServices aboutServices, CompanyServices companyServices, SendEmailServices sendEmailServices, AppointmentServices appointmentServices, ProfessionalServices professionalServices, PrincipleServices principleServices)
        {
            _logger = logger;
            _context = context;
            _qualitysystemServices = qualitysystemServices;
            _aboutServices = aboutServices;
            _companyServices = companyServices;
            _sendEmailServices = sendEmailServices;
            _appointmentServices = appointmentServices;
            _professionalServices = professionalServices;
            _principleServices = principleServices;
        }

        public IActionResult AboutUs()
        {
            AboutUsVM aboutusVM = new()
            {
                QualitySystem = _qualitysystemServices.GetQualitySystemById(1),
                Abouts = _aboutServices.GetAll(),
                Companies = _companyServices.GetAll(),
                Professionals = _professionalServices.GetAll(),
                Principles = _principleServices.GetAll(),
            };
            return View(aboutusVM);
        }
        [HttpPost]
        public IActionResult AboutUs(Appointment appointment, SendEmail sendemail)
        {
            if (appointment.Name != null & appointment.Message != null & appointment.Time != null & appointment.Email != null)
            {

                _appointmentServices.PostAppointment(appointment);

            }
            else if (sendemail.Email != null)
            {
                _sendEmailServices.Post(sendemail);

            }

            return RedirectToAction(nameof(AboutUs));
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
