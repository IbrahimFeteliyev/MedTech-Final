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
    public class ServiceServices
    {
        private readonly MedtechDbContext _context;

        public ServiceServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Service> GetAll()
        {
            var service = _context.Services.ToList();
            return service;
        }

        public void CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(x => x.ID == id);
        }

        public void EditService(Service service, string Name, string Description, string PhotoURL)
        {
            service.Name = Name;
            service.Description = Description;
            service.PhotoURL = PhotoURL;


            _context.Services.Update(service);

            var updatedEntity = _context.Entry(service);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Service GetServiceDetailById(int id)
        {
            return _context.Services.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteService(Service service)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }


    }
}
