using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfessionalServices
    {
        private readonly MedtechDbContext _context;

        public ProfessionalServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Professional> GetAll()
        {
            var professional = _context.Professionals.ToList();
            return professional;
        }

        public void CreateProfessional(Professional professional)
        {
            _context.Professionals.Add(professional);
            _context.SaveChanges();
        }

        public Professional GetProfessionalById(int id)
        {
            return _context.Professionals.FirstOrDefault(x => x.ID == id);
        }

        public void EditProfessional(Professional professional, string Name, string Profession, string Description , string Facebook, string Twitter , string LinkedIn , string Pinterest, string Email, string Phone, string PhotoURL)
        {
            professional.Name = Name;
            professional.Profession = Profession;
            professional.Description = Description;
            professional.Facebook = Facebook;
            professional.Twitter = Twitter;
            professional.LinkedIn = LinkedIn;
            professional.Pinterest = Pinterest;
            professional.Email = Email;
            professional.Phone = Phone;
            professional.PhotoURL = PhotoURL;


            _context.Professionals.Update(professional);

            var updatedEntity = _context.Entry(professional);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Professional GetProfessionalDetailById(int id)
        {
            return _context.Professionals.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteProfessional(Professional professional)
        {
            _context.Professionals.Remove(professional);
            _context.SaveChanges();
        }

    }
}
