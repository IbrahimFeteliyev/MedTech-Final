using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactServices
    {

        private readonly MedtechDbContext _context;

        public ContactServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public void PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

    }
}
