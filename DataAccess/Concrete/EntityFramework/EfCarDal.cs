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

        public List<CarDetailDto> GetCarById(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             where p.Id == id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorId = c.Id,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             where p.BrandId == brandId
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandId=b.Id,
                                 BrandName = b.Name,
                                 ColorId   = c.Id,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }


        public List<CarDetailDto> GetCarsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             where p.ColorId == colorId
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandId=b.Id,
                                 BrandName = b.Name,
                                 ColorId=c.Id,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description
                             };
                return result.ToList();
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
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandId=b.Id,
                                 BrandName = b.Name,
                                 ColorId=c.Id,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 Description=p.Description
                             };

                            return result.ToList();
            }
        }

    }
}
