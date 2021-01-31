using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        public List<Car> _cars;
        public InMemoryCarDal() // Constructor
        {
           _cars = new List<Car>();
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car _car = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(_car);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(p => p.Id == id);
        }

        public void Update(Car car)
        {
            Car _car = _cars.SingleOrDefault(p => p.Id == car.Id);
            _car.Description = car.Description;
            _car.BrandId     = car.BrandId;
            _car.ColorId     = car.ColorId;
            _car.DailyPrice  = car.DailyPrice;
        }
    }
}
