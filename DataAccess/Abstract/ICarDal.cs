using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccess.Concrete
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetails();
    }
}