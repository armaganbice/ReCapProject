using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReCapProject by Armağan Bice 31.01.2021");

            ICarDal CarDal = new InMemoryCarDal(); // InMemoryCarDal *DataAccessLayer 
            ICarService carManager = new CarManager(CarDal);
            // Car Records added Car Database
            Car car1 = new Car();
            car1.Id = 1;
            car1.BrandId = 1;
            car1.ColorId = 1;
            car1.DailyPrice = 300;
            car1.Description = "Renault";
            carManager.Add(car1);
            // ------------------
            Car car2 = new Car();
            car2.Id = 2;
            car2.BrandId = 2;
            car2.ColorId = 3;
            car2.DailyPrice = 400;
            car2.Description = "Fiat";
            carManager.Add(car2);
            // ----------------------
            Car car3 = new Car();
            car3.Id = 3;
            car3.BrandId = 3;
            car3.ColorId = 3;
            car3.DailyPrice = 900;
            car3.Description = "Mercedes";
            carManager.Add(car3);
            // ---------------------------
            List<Car> cars = new List<Car>();
            cars=carManager.GetAll();
            Console.WriteLine("Rented Car List - GetAll() ");
            foreach(Car item in cars)
            {
                Console.WriteLine(item.Id + " - "+item.Description);
            }
            Console.WriteLine("Delete Car "+car3.Description);
            carManager.Delete(car3);
            cars = carManager.GetAll();
            Console.WriteLine("Rented Car List after Delete Operation");
            foreach (Car item in cars)
            {
                Console.WriteLine(item.Id+" - "+item.Description);
            }
            Console.WriteLine("Car Update() "+car2.Description);
            car2.Description = "Fiat Egea";
            carManager.Update(car2);
            Console.WriteLine("Car Update "+carManager.GetById(car2.Id).Description);
            cars = carManager.GetAll();
            Console.WriteLine("Rented Car List After Description Update");
            foreach (Car item in cars)
            {
                Console.WriteLine(item.Id + " - "+item.Description);
            }
            Console.WriteLine("GetId from Cars Database");
            Console.WriteLine("Id=1  Car Description=" + carManager.GetById(1).Description);
            Console.ReadLine();
        }
    }
}
