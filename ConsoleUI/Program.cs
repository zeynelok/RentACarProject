using Business.Concrete;
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
            //InMemoryCarManagerTest();
            //CarDelete();
            //BrandAdd();
            //GetAllBrand();
            //CollorsAdd();
            //CarsAdd();
            //GetCarDetail();
            //UsersAdd();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            List<Customer> customers = new List<Customer> {
                new Customer{Id=1,UserId=1,CompanyName="Zeynel'in şirketi"},
                new Customer{Id=2,UserId=2,CompanyName="Zeyn'in şirketi"},
                new Customer{Id=3,UserId=3,CompanyName="Zey'in şirketi"},
                new Customer{Id=4,UserId=3,CompanyName="Zey'in 2. şirketi"},

              

            };
            foreach (var item in customers)
            {
                customerManager.AddCustomer(item);
                Console.WriteLine("işlem tamam");
            }

        }

        //private static void UsersAdd()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    List<User> users = new List<User> {
        //        new User{Id=1,Email="1@gmail.com",FirstName="Zeynel",LastName="Ok",Password="12"},
        //        new User{Id=2,Email="2@gmail.com",FirstName="Zeyn",LastName="Okk",Password="13"},
        //        new User{Id=3,Email="3@gmail.com",FirstName="Zey",LastName="Okkk",Password="14"},

        //    };
        //    foreach (var item in users)
        //    {
        //        userManager.AddUser(item);
        //        Console.WriteLine("işlem tamam");
        //    }
        //}

        private static void GetCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.BrandName + " /" + item.CarName + " /" + item.ColorName + " /" + item.DailyPrice);
            }
        }

        private static void CarsAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = new List<Car> {
                new Car{Id = 1,BrandId=1,CarName="Corolla",ColorId=1,DailyPrice=150,Description="Benim Babam toyota gibi adam", ModelYear=2020},
                new Car{Id = 2,BrandId=2,CarName="Kartal",ColorId=2,DailyPrice=50,Description="Tofaşk",ModelYear=1994},
                new Car{Id = 3, BrandId=3,CarName="l200",ColorId=2,DailyPrice=200,Description="L200 adamdır",ModelYear=2018 },
                new Car{Id = 4,BrandId=4,CarName="Mustang",ColorId=1,DailyPrice=200,Description="asasfadsfa",ModelYear=2020  },
                new Car{Id = 5,BrandId=5,CarName="C200",ColorId=3,DailyPrice=250,Description="Paramız yetmez",ModelYear=2020 }
            };
            foreach (var item in cars)
            {
                carManager.AddCar(item);
            }
            Console.WriteLine("işlem tamam");
        }

        private static void CollorsAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            List<Color> colors = new List<Color> {
                new Color{Id = 1, ColorName = "Red" },
                new Color{Id = 2, ColorName = "White" },
                new Color{Id = 3, ColorName = "Blue" },
                new Color{Id = 4, ColorName = "Yellow" },
                new Color{Id = 5, ColorName = "Green" }
            };
            foreach (var item in colors)
            {
                colorManager.AddColor(item);
            }
            Console.WriteLine("işlem tamam");
        }

        private static void GetAllBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            List<Brand> brands = new List<Brand> {
                new Brand{Id = 1, BrandName = "Toyota" },
                new Brand{Id = 2, BrandName = "Tofaş" },
                new Brand{Id = 3, BrandName = "Mitsubishi" },
                new Brand{Id = 4, BrandName = "Ford" },
                new Brand{Id = 5, BrandName = "Mercedes" }
            };
            foreach (var item in brands)
            {
                brandManager.AddBrand(item);
            }
            Console.WriteLine("işlem tamam");
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { BrandId = 1, ColorId = 1, DailyPrice = 10, Description = "asasasa", Id = 1, ModelYear = 2012, CarName = "Doğan" };

            carManager.DeleteCar(car);
        }

        private static void InMemoryCarManagerTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.ModelYear);
            }
        }
    }
}
