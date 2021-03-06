using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
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
             CarEfMethods1("Test Entity Framework");
            //CarEfMethods2("Test Entity Framework");
        }

        public static void CarEfMethods1(string test)
        {
            ICarDal CarDal = new EfCarDal(); // EfCarDal *DataAccessLayer 
            ICarService carManager = new CarManager(CarDal);

            CarRentalContext carRentalContext = new CarRentalContext();
            foreach (Car car in carRentalContext.Cars)
            {
                Console.WriteLine(car.Description);
            }
            Car car4 = new Car();
            //car4.Id = 4;
            car4.BrandId = 5;
            car4.ColorId = 5;
            car4.DailyPrice = 0;
            car4.Name = "A";
            car4.Description = "A";
            carManager.Add(car4);
            Console.WriteLine("EF Cars List");
            foreach (Car car in carRentalContext.Cars)
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
           // car4.Description = "Audi A6";
           // carManager.Update(car4);
            CarRentalContext context = new CarRentalContext();
            Console.WriteLine("EF Cars List after Update with context.Cars");
            foreach (Car car in context.Cars)
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
            // carManager.Delete(car4);
            Console.WriteLine("EF Cars List after delete with GetAll() ");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " - " + car.Description);
            }
            // Console.WriteLine("Get By Id 1 " + carManager.GetById(1).Description);
            Console.WriteLine("EF Cars List BrandId=1 ");
            foreach (Car car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Id.ToString() + "-" + car.BrandId.ToString() + " - " + car.Description);
            }
            Console.WriteLine("EF Cars List ColorId=2 ");
            foreach (Car car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Id.ToString() + "-" + car.ColorId.ToString() + " - " + car.Description);
            }
            IColorDal colorDal = new EfColorDal();
            ColorManager colorManager = new ColorManager(colorDal);
            //Color color6 = new Color();
            //color1.Id = 1;
            //color1.Name = "White";
            //colorManager.Add(color1);
            //Color color2 = new Color();
            //color2.Id = 1;
            //color2.Name = "Red";
            //colorManager.Add(color2);
            //Color color5 = new Color();
            //color5.Id = 6;
            //color5.Name = "Purple";
            //colorManager.Add(color5);
            Console.WriteLine("EF Color List");
            foreach (Color color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id.ToString() +" - " + color.Name);
            }
            IBrandDal brandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(brandDal);
            //Brand brand1 = new Brand();
            //brand1.Id = 1;
            //brand1.Name = "Fiat";
            //Brand brand2 = new Brand();
            //brand2.Id = 2;
            //brand2.Name = "Renault";
            //Brand brand3 = new Brand();
            //brand3.Id = 3;
            //brand3.Name = "Mercedes";
            //Brand brand4 = new Brand();
            //brand4.Id = 4;
            //brand4.Name = "Audi";
            //brandManager.Add(brand1);
            //brandManager.Add(brand2);
            //brandManager.Add(brand3);
            //brandManager.Add(brand4);
            Console.WriteLine("EF Brand List");
            foreach (Brand brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id.ToString() + " - " + brand.Name);
            }

            foreach (CarDetailDto carDetailDto in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} ", carDetailDto.CarName.ToString() ,carDetailDto.BrandName,carDetailDto.ColorName,carDetailDto.DailyPrice);
            }

            Console.ReadLine();
        }

        public static void CarEfMethods2(string test)
        {
            Console.WriteLine("ReCapProject by Armağan Bice 13.02.2021");
            Console.WriteLine("---------------------------------------");
            
            CarRentalContext carRentalContext = new CarRentalContext();
            IUserDal UserDal = new EfUserDal(); // EfCarDal *DataAccessLayer 
            IUserService userManager = new UserManager(UserDal);
            
            //User user1 = new User();
            //user1.FirstName = "Engin";
            //user1.LastName = "Demiroğ";
            //userManager.Add(user1);
            //User user2 = new User();
            //user2.FirstName = "Armağan";
            //user2.LastName = "Bice";
            //userManager.Add(user2);
            User user3 = new User();
            user3.Id = 3;
            user3.FirstName = "Ahmet";
            user3.LastName = "Kaya";

            userManager.Update(user3);
            User user4 = new User();
            user4.Id = 4;
            user4.FirstName = "Arda";
            user4.LastName = "Bice";
            userManager.Update(user4);
            Console.WriteLine("EF User List ");
            foreach (User user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id.ToString() + "-" + user.FirstName.ToString() + " - " + user.LastName);
            }

            ICustomerDal CustomerDal = new EfCustomerDal(); // EfCarDal *DataAccessLayer 
            ICustomerService customerManager = new CustomerManager(CustomerDal);
            //Customer customer1 = new Customer();
            //customer1.UserId = 1;
            //customer1.CompanyName = "ABICE CO.";
            //customerManager.Add(customer1);
            //Customer customer2 = new Customer();
            //customer2.UserId = 2;
            //customer2.CompanyName = "SolidTeam";
            //customerManager.Add(customer2);
            Console.WriteLine("EF Customer List ");
            foreach (Customer customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.Id.ToString() + "-" + customer.UserId.ToString() + " - " + customer.CompanyName);
            }

            IRentalDal RentalDal = new EfRentalDal(); // EfCarDal *DataAccessLayer 
            IRentalService rentalManager = new RentalManager(RentalDal);
            Rental rental1 = new Rental();
            rental1.CarId = 1;
            rental1.CustomerId = 1;
            rental1.RentDate = DateTime.Now;
            rentalManager.Add(rental1);
            Rental rental2 = new Rental();
            rental2.CarId = 2;
            rental2.CustomerId = 2;
            rental2.RentDate = DateTime.Now;
            rentalManager.Add(rental2);
            Console.WriteLine("EF Rental List ");
            foreach (Rental rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} ", rental.CarId.ToString(),rental.CustomerId.ToString(), rental.RentDate, rental.ReturnDate);
            }
            Console.WriteLine("EF Rental List - DTO  ");
            foreach (RentalDetailDto rentalDetailDto in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4} / {5} ",
                    rentalDetailDto.Id,
                    rentalDetailDto.CarName.ToString(), 
                    rentalDetailDto.FirstName,
                    rentalDetailDto.LastName,
                    rentalDetailDto.RentDate,
                    rentalDetailDto.ReturnDate
                    );
            }
            Console.ReadLine();

        }

        public static void CarInMemoryMethods(string test)
        {
            //ICarDal CarDal = new InMemoryCarDal(); // InMemoryCarDal *DataAccessLayer 
            //ICarService carManager = new CarManager(CarDal);
            //// Car Records added Car Database
            //Car car1 = new Car();
            //car1.Id = 1;
            //car1.BrandId = 1;
            //car1.ColorId = 1;
            //car1.DailyPrice = 300;
            //car1.Description = "Renault";
            //carManager.Add(car1);
            //// ------------------
            //Car car2 = new Car();
            //car2.Id = 2;
            //car2.BrandId = 2;
            //car2.ColorId = 3;
            //car2.DailyPrice = 400;
            //car2.Description = "Fiat";
            //carManager.Add(car2);
            //// ----------------------
            //Car car3 = new Car();
            //car3.Id = 3;
            //car3.BrandId = 3;
            //car3.ColorId = 3;
            //car3.DailyPrice = 900;
            //car3.Description = "Mercedes";
            //carManager.Add(car3);
            // ---------------------------
            //List<Car> cars = new List<Car>();
            //cars = carManager.GetAll();
            //Console.WriteLine("Rented Car List - GetAll() ");
            //foreach (Car item in cars)
            //{
            //    Console.WriteLine(item.Id + " - " + item.Description);
            //}
            //Console.WriteLine("Delete Car " + car3.Description);
            //carManager.Delete(car3);
            //cars = carManager.GetAll();
            //Console.WriteLine("Rented Car List after Delete Operation");
            //foreach (Car item in cars)
            //{
            //    Console.WriteLine(item.Id + " - " + item.Description);
            //}
            //Console.WriteLine("Car Update() " + car2.Description);
            //car2.Description = "Fiat Egea";
            //carManager.Update(car2);
            //Console.WriteLine("Car Update " + carManager.GetById(car2.Id).Description);
            //cars = carManager.GetAll();
            //Console.WriteLine("Rented Car List After Description Update");
            //foreach (Car item in cars)
            //{
            //    Console.WriteLine(item.Id + " - " + item.Description);
            //}
            //Console.WriteLine("GetId from Cars Database");
            //Console.WriteLine("Id=1  Car Description=" + carManager.GetById(1).Description);

        }
    }
}
