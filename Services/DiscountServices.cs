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
    public class DiscountServices
    {
        private readonly MedtechDbContext _context;

        public DiscountServices(MedtechDbContext context)
        {
            _context = context;
        }

        public List<Discount> GetAll()
        {
            var discount = _context.Discounts.ToList();
            return discount;
        }

        public void CreateDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public Discount GetDiscountById()
        {
            return _context.Discounts.FirstOrDefault();
        }

        public void EditDiscount(Discount discount, string Title, string DiscountOFF, string PhotoURL)
        {
            discount.Title = Title;
            discount.DiscountOFF = DiscountOFF;
            discount.PhotoURL = PhotoURL;

            _context.Discounts.Update(discount);

            var updatedEntity = _context.Entry(discount);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Discount GetDiscountDetailById(int id)
        {
            return _context.Discounts.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteDiscount(Discount discount)
        {
            _context.Discounts.Remove(discount);
            _context.SaveChanges();
        }


    }
}
