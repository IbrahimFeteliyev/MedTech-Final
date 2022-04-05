using Entities;

namespace K205Medtech.ViewModels
{
    public class OurTeamVM
    {
        public List<Company> Companies { get; set; }
        public Appointment Appointment { get; set; }
        public SendEmail SendEmail { get; set; }
        public List<Principle> Principles { get; set; }
        public List<Professional> Professionals { get; set; }
        public Professional Professional { get; set; }
    }
}
