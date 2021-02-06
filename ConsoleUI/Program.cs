using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            Console.WriteLine("---------------------------------------");
            // CarInMemoryMethods("Test In Memory");
            CarEfMethods("Test Entity Framework");
        }

        public static void CarEfMethods(string test)
        {
            ICarDal CarDal = new EfCarDal(); // EfCarDal *DataAccessLayer 
            ICarService carManager = new CarManager(CarDal);

            CarRentalContext carRentalContext = new CarRentalContext();
            foreach (Car car in carRentalContext.Cars)
            {
                Console.WriteLine(car.Description);
            }
            Car car4 = new Car();
            car4.Id = 4;
            car4.BrandId = 4;
            car4.ColorId = 4;
            car4.DailyPrice = 900;
            car4.Description = "Audi";
            carManager.Add(car4);
            Console.WriteLine("EF Cars List");
            foreach (Car car in carRentalContext.Cars)
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
            car4.Description = "Audi A6";
            carManager.Update(car4);
            CarRentalContext context = new CarRentalContext();
            Console.WriteLine("EF Cars List after Update with context.Cars");
            foreach (Car car in context.Cars)
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
            carManager.Delete(car4);
            Console.WriteLine("EF Cars List after delete with GetAll() ");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
            Console.WriteLine("Get By Id 1 " + carManager.GetById(1).Description);
            Console.WriteLine("EF Cars List BrandId=1 ");
            foreach (Car car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Id.ToString() +"-"+ car.BrandId.ToString()+" - " + car.Description);
            }
            Console.WriteLine("EF Cars List ColorId=2 ");
            foreach (Car car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Id.ToString() +"-"+ car.ColorId.ToString()+" - " + car.Description);
            }
            IColorDal colorDal = new EfColorDal();
            ColorManager colorManager = new ColorManager(colorDal);
            //Color color1= new Color();
            //color1.Name = "White";
            //colorManager.Add(color1);
            //Color color2 = new Color();
            //color2.Name = "Red";
            //colorManager.Add(color2);
            Console.WriteLine("EF Color List");
            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id.ToString() +" - " + color.Name);
            }
            IBrandDal brandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(brandDal);
            Brand brand1 = new Brand();
            brand1.Id = 1;
            brand1.Name = "Fiat";
            Brand brand2 = new Brand();
            brand2.Id = 2;
            brand2.Name = "Renault";
            Brand brand3 = new Brand();
            brand3.Id = 3;
            brand3.Name = "Mercedes";
            Brand brand4 = new Brand();
            brand4.Id = 4;
            brand4.Name = "Audi";
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
            brandManager.Add(brand4);
            Console.WriteLine("EF Brand List");
            foreach (Brand brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id.ToString() + " - " + brand.Name);
            }
            Console.ReadLine();
        }
        public static void CarInMemoryMethods(string test)
        {
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
            cars = carManager.GetAll();
            Console.WriteLine("Rented Car List - GetAll() ");
            foreach (Car item in cars)
            {
                Console.WriteLine(item.Id + " - " + item.Description);
            }
            Console.WriteLine("Delete Car " + car3.Description);
            carManager.Delete(car3);
            cars = carManager.GetAll();
            Console.WriteLine("Rented Car List after Delete Operation");
            foreach (Car item in cars)
            {
                Console.WriteLine(item.Id + " - " + item.Description);
            }
            Console.WriteLine("Car Update() " + car2.Description);
            car2.Description = "Fiat Egea";
            carManager.Update(car2);
            Console.WriteLine("Car Update " + carManager.GetById(car2.Id).Description);
            cars = carManager.GetAll();
            Console.WriteLine("Rented Car List After Description Update");
            foreach (Car item in cars)
            {
                Console.WriteLine(item.Id + " - " + item.Description);
            }
            Console.WriteLine("GetId from Cars Database");
            Console.WriteLine("Id=1  Car Description=" + carManager.GetById(1).Description);

        }
    }
}
