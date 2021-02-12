using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext> , ICarDal 
    {
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                 return context.Cars.Where(p => p.BrandId == brandId).ToList();
                //return null;
            }
        }


        public List<Car> GetCarsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Cars.Where(p => p.ColorId == colorId).ToList();
               // return null;
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarName = p.Description,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice
                             };

                            return result.ToList();
                // return null;
            }
        }

    }
}
