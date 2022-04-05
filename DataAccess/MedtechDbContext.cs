using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MedtechDbContext : DbContext
    {
        public MedtechDbContext(DbContextOptions<MedtechDbContext> options)
           : base(options)
        {

        }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<QualitySystem> QualitySystems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<PatientsSay> PatientsSays { get; set; }
        public DbSet<LastNew> LastNews { get; set; }
        public DbSet<MobileApp> MobileApps { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SendEmail> SendEmails { get; set; }
        public DbSet<Principle> Principles { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Contact> Contacts { get; set; }



    }

}
