using Entities;

namespace K205Medtech.Areas.admin.ViewModel
{
    public class EditVM
    {
        public Introduction Introduction { get; set; }
        public List<Service> Services { get; set; }
        public Service Service { get; set; }
        public QualitySystem QualitySystem { get; set; }
        public Discount Discount { get; set; }
        public List<About> Abouts { get; set; }
        public About About { get; set; }
        public List<PatientsSay> PatientsSays { get; set; }
        public PatientsSay PatientsSay { get; set; }
        public List<LastNew> LastNews { get; set; }
        public LastNew LastNew { get; set; }
        public MobileApp MobileApp { get; set; }
        public List<Company> Companies { get; set; }
        public Company Company { get; set; }
        public List<Principle> Principles { get; set; }
        public Principle Principle { get; set; }
        public List<Professional> Professionals { get; set; }
        public Professional Professional { get; set; }


    }
}
