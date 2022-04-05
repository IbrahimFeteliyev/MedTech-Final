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
    public class PrincipleServices
    {
        private readonly MedtechDbContext _context;

        public PrincipleServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Principle> GetAll()
        {
            var principle = _context.Principles.ToList();
            return principle;
        }

        public void CreatePrinciple(Principle principle)
        {
            _context.Principles.Add(principle);
            _context.SaveChanges();
        }

        public Principle GetPrincipleById(int id)
        {
            return _context.Principles.FirstOrDefault(x => x.ID == id);
        }

        public void EditPrinciple(Principle principle, string Title, string Description, string PhotoURL)
        {
            principle.Title = Title;
            principle.Description = Description;
            principle.PhotoURL = PhotoURL;


            _context.Principles.Update(principle);

            var updatedEntity = _context.Entry(principle);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Principle GetPrincipleDetailById(int id)
        {
            return _context.Principles.FirstOrDefault(x => x.ID == id);
        }

        public void DeletePrinciple(Principle principle)
        {
            _context.Principles.Remove(principle);
            _context.SaveChanges();
        }


    }
}
