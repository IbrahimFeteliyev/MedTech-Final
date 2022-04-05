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
    public class PatientsSayServices
    {

        private readonly MedtechDbContext _context;

        public PatientsSayServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<PatientsSay> GetAll()
        {
            var patientssay = _context.PatientsSays.ToList();
            return patientssay;
        }

        public void CreatePatientsSay(PatientsSay patientssay)
        {
            _context.PatientsSays.Add(patientssay);
            _context.SaveChanges();
        }

        public PatientsSay GetPatientsSayById(int id)
        {
            return _context.PatientsSays.FirstOrDefault(x => x.ID == id);
        }

        public void EditPatientsSay(PatientsSay patientssay, string PatientName, string Patient, string Description, string PatientPhoto)
        {
            patientssay.PatientName = PatientName;
            patientssay.Patient = Patient;
            patientssay.Description = Description;
            patientssay.PatientPhoto = PatientPhoto;


            _context.PatientsSays.Update(patientssay);

            var updatedEntity = _context.Entry(patientssay);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public PatientsSay GetPatientsSayDetailById(int id)
        {
            return _context.PatientsSays.FirstOrDefault(x => x.ID == id);
        }

        public void DeletePatientsSay(PatientsSay patientssay)
        {
            _context.PatientsSays.Remove(patientssay);
            _context.SaveChanges();
        }



    }
}
