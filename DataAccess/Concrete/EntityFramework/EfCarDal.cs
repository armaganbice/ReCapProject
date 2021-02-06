using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using( CarRentalContext context = new CarRentalContext())
            {
                Car addedCar = context.Cars.SingleOrDefault(p => p.Id == entity.Id);
                if (addedCar == null)
                {
                    context.Cars.Add(entity);
                    context.SaveChanges();
                }
            }
       }

        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Car deletedCar=context.Cars.SingleOrDefault(p => p.Id == entity.Id);
                context.Cars.Remove(deletedCar);
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Cars.ToList();
            }
        }
 
        public Car GetById(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Cars.SingleOrDefault(p => p.Id == id);
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Cars.Where(p => p.BrandId == brandId).ToList();
            }
        }

      
        public List<Car> GetCarsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Cars.Where(p => p.ColorId == colorId).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                Car updatedCar = context.Cars.SingleOrDefault(p => p.Id == entity.Id);
                updatedCar.Description = entity.Description;
                updatedCar.ModelYear = entity.ModelYear;
                updatedCar.BrandId = entity.BrandId;
                updatedCar.ColorId = entity.ColorId;
                updatedCar.DailyPrice = entity.DailyPrice;
                context.SaveChanges();
            }
        }
    }
}
