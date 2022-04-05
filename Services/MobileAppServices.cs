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
    public class MobileAppServices
    {
        private readonly MedtechDbContext _context;

        public MobileAppServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<MobileApp> GetAll()
        {
            var mobileapp = _context.MobileApps.ToList();
            return mobileapp;
        }

        public void CreateMobileApp(MobileApp mobileapp)
        {
            _context.MobileApps.Add(mobileapp);
            _context.SaveChanges();
        }

        public MobileApp GetMobileAppById(int id)
        {
            return _context.MobileApps.FirstOrDefault(x => x.ID == id);
        }

        public void EditMobileApp(MobileApp mobileapp, string Title, string Description, string PhotoURL)
        {
            mobileapp.Title = Title;
            mobileapp.Description = Description;
            mobileapp.PhotoURL = PhotoURL;

            _context.MobileApps.Update(mobileapp);

            var updatedEntity = _context.Entry(mobileapp);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public MobileApp GetMobileAppDetailById(int id)
        {
            return _context.MobileApps.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteMobileApp(MobileApp mobileapp)
        {
            _context.MobileApps.Remove(mobileapp);
            _context.SaveChanges();
        }




    }
}
