using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SendEmailServices
    {
        private readonly MedtechDbContext _context;

        public SendEmailServices(MedtechDbContext context)
        {
            _context = context;
        }

        public void Post(SendEmail sendemail)
        {
            _context.SendEmails.Add(sendemail);
            _context.SaveChanges();
        }
    }
}
