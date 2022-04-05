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

    public class QualitySystemServices
    {
        private readonly MedtechDbContext _context;

        public QualitySystemServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<QualitySystem> GetAll()
        {
            var qualitysystem = _context.QualitySystems.ToList();
            return qualitysystem;
        }

        public void CreateQualitySystem(QualitySystem qualitysystem)
        {
            _context.QualitySystems.Add(qualitysystem);
            _context.SaveChanges();
        }

        public QualitySystem GetQualitySystemById(int id)
        {
            return _context.QualitySystems.FirstOrDefault(x => x.ID == id);
        }

        public void EditQualitySystem(QualitySystem qualitysystem, string Title, string Description, string Service, string PhotoURL)
        {

            qualitysystem.Title = Title;
            qualitysystem.Description = Description;
            qualitysystem.Service = Service;
            qualitysystem.PhotoURL = PhotoURL;


            _context.QualitySystems.Update(qualitysystem);

            var updatedEntity = _context.Entry(qualitysystem);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public QualitySystem GetQualitySystemDetailById(int id)
        {
            return _context.QualitySystems.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteQualitySystem(QualitySystem qualitysystem)
        {
            _context.QualitySystems.Remove(qualitysystem);
            _context.SaveChanges();
        }


    }
}

