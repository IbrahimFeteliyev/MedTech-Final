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
    public class IntroductionServices
    {
        private readonly MedtechDbContext _context;

        public IntroductionServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Introduction> GetAll()
        {
            var introduction = _context.Introductions.ToList();
            return introduction;
        }

        public void CreateIntroduction(Introduction introduction)
        {
            _context.Introductions.Add(introduction);
            _context.SaveChanges();
        }

        public Introduction GetIntroductionById(int id)
        {       
            return _context.Introductions.FirstOrDefault(x => x.ID == id);
        }

        public void EditIntroduction(Introduction introduction,string Heading, string Title, string Description, string PhotoURL)
        {
            introduction.Heading = Heading;
            introduction.Title = Title;
            introduction.Description = Description;
            introduction.PhotoURL = PhotoURL;

            _context.Introductions.Update(introduction);

            var updatedEntity = _context.Entry(introduction);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Introduction GetIntroductionDetailById(int id)
        {
            return _context.Introductions.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteIntroduction(Introduction introduction)
        {
            _context.Introductions.Remove(introduction);
            _context.SaveChanges();
        }
        

    }
}
