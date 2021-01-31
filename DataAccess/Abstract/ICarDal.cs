using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public interface ICarDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int id);
        List<Car> GetAll();

    }
}