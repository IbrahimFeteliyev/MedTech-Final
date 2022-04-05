using DataAccess;
using Entities;
using K205Medtech.Models;
using K205Medtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Medtech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MedtechDbContext _context;
        private readonly IntroductionServices _introductionServices;
        private readonly ServiceServices _serviceServices;
        private readonly QualitySystemServices _qualitysystemServices;
        private readonly DiscountServices _discountServices;
        private readonly AboutServices _aboutServices;
        private readonly PatientsSayServices _patientssayServices;
        private readonly LastNewServices _lastnewServices;
        private readonly MobileAppServices _mobileappServices;
        private readonly CompanyServices _companyServices;
        private readonly SendEmailServices _sendEmailServices;
        private readonly AppointmentServices _appointmentServices;



        public HomeController(ILogger<HomeController> logger, MedtechDbContext context, IntroductionServices introductionServices, ServiceServices serviceServices, QualitySystemServices qualitysystemServices, DiscountServices discountServices, AboutServices aboutServices, PatientsSayServices patientssayServices, LastNewServices lastnewServices, MobileAppServices mobileappServices, CompanyServices companyServices, SendEmailServices sendEmailServices, AppointmentServices appointmentServices)
        {
            _logger = logger;
            _context = context;
            _introductionServices = introductionServices;
            _serviceServices = serviceServices;
            _qualitysystemServices = qualitysystemServices;
            _discountServices = discountServices;
            _aboutServices = aboutServices;
            _patientssayServices = patientssayServices;
            _lastnewServices = lastnewServices;
            _mobileappServices = mobileappServices;
            _companyServices = companyServices;
            _sendEmailServices = sendEmailServices;
            _appointmentServices = appointmentServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Introduction = _introductionServices.GetIntroductionById(1),
                Services = _serviceServices.GetAll(),
                QualitySystem = _qualitysystemServices.GetQualitySystemById(1),
                Discount = _discountServices.GetDiscountById(),
                Abouts = _aboutServices.GetAll(),
                PatientsSays = _patientssayServices.GetAll(),
                LastNews = _lastnewServices.GetAll(),
                MobileApp = _mobileappServices.GetMobileAppById(1),
                Companies = _companyServices.GetAll(),
            };
            return View(homeVM);
        }
        [HttpPost]
        public IActionResult Index(Appointment appointment, SendEmail sendemail)
        {
            if (appointment.Name != null & appointment.Message != null & appointment.Time != null & appointment.Email != null)
            {

                _appointmentServices.PostAppointment(appointment);

            }
            else if (sendemail.Email != null)
            {
                _sendEmailServices.Post(sendemail);

            }

            return RedirectToAction(nameof(Index));
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