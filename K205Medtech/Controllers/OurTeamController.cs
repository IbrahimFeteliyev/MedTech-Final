using DataAccess;
using Entities;
using K205Medtech.Models;
using K205Medtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Medtech.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly ILogger<OurTeamController> _logger;
        private readonly MedtechDbContext _context;
        private readonly CompanyServices _companyServices;
        private readonly SendEmailServices _sendEmailServices;
        private readonly AppointmentServices _appointmentServices;
        private readonly ProfessionalServices _professionalServices;
        private readonly PrincipleServices _principleServices;


        public OurTeamController(ILogger<OurTeamController> logger, MedtechDbContext context,   CompanyServices companyServices, SendEmailServices sendEmailServices, AppointmentServices appointmentServices, ProfessionalServices professionalServices, PrincipleServices principleServices)
        {
            _logger = logger;
            _context = context;
            _companyServices = companyServices;
            _sendEmailServices = sendEmailServices;
            _appointmentServices = appointmentServices;
            _professionalServices = professionalServices;
            _principleServices = principleServices;
        }

        public IActionResult OurTeam()
        {
            OurTeamVM aboutusVM = new()
            {
                Companies = _companyServices.GetAll(),
                Professionals = _professionalServices.GetAll(),
                Principles = _principleServices.GetAll(),
            };
            return View(aboutusVM);
        }
        [HttpPost]
        public IActionResult OurTeam(Appointment appointment, SendEmail sendemail)
        {
            if (appointment.Name != null & appointment.Message != null & appointment.Time != null & appointment.Email != null)
            {

                _appointmentServices.PostAppointment(appointment);

            }
            else if (sendemail.Email != null)
            {
                _sendEmailServices.Post(sendemail);

            }

            return RedirectToAction(nameof(OurTeam));
        }
        public IActionResult TeamDetail(int? id)
        {
            OurTeamVM ourTeamVM = new()
            {
                Professional = _professionalServices.GetProfessionalById(id.Value),
            };
            return View(ourTeamVM);
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
