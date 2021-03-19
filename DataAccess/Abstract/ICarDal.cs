using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccess.Concrete
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarById(int id);
    }
}