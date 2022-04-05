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
    public class LastNewServices
    {

        private readonly MedtechDbContext _context;

        public LastNewServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<LastNew> GetAll()
        {
            var lastnew = _context.LastNews.ToList();
            return lastnew;
        }

        public void CreateLastNew(LastNew lastnew)
        {
            _context.LastNews.Add(lastnew);
            _context.SaveChanges();
        }

        public LastNew GetLastNewById(int id)
        {
            return _context.LastNews.FirstOrDefault(x => x.ID == id);
        }

        public void EditLastNew(LastNew lastnew, string Name, string Title, string Description, string PhotoURL)
        {
            lastnew.Name = Name;
            lastnew.Title = Title;
            lastnew.Description = Description;
            lastnew.PhotoURL = PhotoURL;


            _context.LastNews.Update(lastnew);

            var updatedEntity = _context.Entry(lastnew);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public LastNew GetLastNewDetailById(int id)
        {
            return _context.LastNews.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteLastNew(LastNew lastnew)
        {
            _context.LastNews.Remove(lastnew);
            _context.SaveChanges();
        }




    }
}
