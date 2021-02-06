using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Brand addedBrand = context.Brands.SingleOrDefault(p => p.Id == entity.Id);
                if (addedBrand == null)
                {
                   // entity.Id = context.Brands.Count() + 1;
                    context.Brands.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Update(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Brand updatedBrand = context.Brands.SingleOrDefault(p => p.Id == entity.Id);
                updatedBrand.Name = entity.Name;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Brand deletedBrand = context.Brands.SingleOrDefault(p => p.Id == entity.Id);
                context.Brands.Remove(deletedBrand);
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Brands.ToList();
            }
        }

        public Brand GetById(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Brands.SingleOrDefault(p => p.Id == id);
            }
        }

    }
}
