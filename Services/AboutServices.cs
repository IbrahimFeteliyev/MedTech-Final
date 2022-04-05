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
    public class AboutServices
    {
        private readonly MedtechDbContext _context;

        public AboutServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<About> GetAll()
        {
            var about = _context.Abouts.ToList();
            return about;
        }

        public void CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
        }

        public About GetAboutById(int id)
        {
            return _context.Abouts.FirstOrDefault(x => x.ID == id);
        }

        public void EditAbout(About about, int Count, string Text, string PhotoURL)
        {
            about.Count = Count;
            about.Text = Text;
            about.PhotoURL = PhotoURL;


            _context.Abouts.Update(about);

            var updatedEntity = _context.Entry(about);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public About GetAboutDetailById(int id)
        {
            return _context.Abouts.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteAbout(About about)
        {
            _context.Abouts.Remove(about);
            _context.SaveChanges();
        }


    }

}

