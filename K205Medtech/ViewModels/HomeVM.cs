using Entities;

namespace K205Medtech.ViewModels
{
    public class HomeVM
    {
        public Introduction Introduction { get; set; }
        public List<Service> Services { get; set; }
        public QualitySystem QualitySystem { get; set; }
        public Discount Discount { get; set; }
        public List<About> Abouts { get; set; }
        public List<PatientsSay> PatientsSays { get; set; }
        public List<LastNew> LastNews { get; set; }
        public MobileApp MobileApp { get; set; }
        public List<Company> Companies { get; set; }
        public Appointment Appointment { get; set; }
        public SendEmail SendEmail { get; set; }
        public Contact Contact { get; set; }





    }
}
