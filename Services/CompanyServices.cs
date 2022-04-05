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
    public class CompanyServices
    {

        private readonly MedtechDbContext _context;

        public CompanyServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Company> GetAll()
        {
            var company = _context.Companies.ToList();
            return company;
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.ID == id);
        }

        public void EditCompany(Company company, string PhotoURL)
        {

            company.PhotoURL = PhotoURL;


            _context.Companies.Update(company);

            var updatedEntity = _context.Entry(company);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Company GetCompanyDetailById(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
    }
}
