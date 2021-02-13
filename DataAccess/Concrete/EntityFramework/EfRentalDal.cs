using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from p in context.Rentals
                             join r in context.Cars
                             on p.CarId equals r.Id
                             join c in context.Colors
                             on r.ColorId equals c.Id
                             join b in context.Brands
                             on r.BrandId equals b.Id
                             join t in context.Customers
                             on p.CustomerId equals t.Id
                             join u in context.Users
                             on t.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id=p.Id,
                                 CustomerId=t.Id,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 CompanyName=t.CompanyName,
                                 CarName = r.Description,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = r.DailyPrice,
                                 RentDate=p.RentDate,
                                 ReturnDate=p.ReturnDate
                             };

                return result.ToList();
                // return null;
            }
        }
    }
}
