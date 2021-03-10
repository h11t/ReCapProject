using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Hello! THIS IS RECAP PROJECT-------------");
            //CarTest();

            //ColorTest();

            //BrandTest();

            //CarDetailsTest();

            UserManager userManager = new UserManager(new EFUserDal());
            userManager.Add(new User() {   FirstName="Hayri", LastName="Bacaksız", Email="hayri.bacaksiz@hb.com", Password="123"  });
            userManager.Add(new User() { FirstName = "Bahri", LastName = "Kolsuz", Email = "bahri.kolsuz@bk.com", Password = "456" });
            userManager.Add(new User() { FirstName = "Zeki", LastName = "Kafasız", Email = "zeki.kafasiz@zk.com", Password = "789" });

            Console.WriteLine("Bütün kullanıcılar .......");
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("Id:"+item.Id+"  FirstName:"+item.FirstName+ "  LastName:"+item.LastName);
            }

            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            customerManager.Add(new Customer() { UserId=2, CompanyName="KOLSUZLAR A.Ş" });
            customerManager.Add(new Customer() { UserId = 3, CompanyName = "HEADLESS A.Ş" });
            Console.WriteLine("Bütün Müşteriler .......");
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.UserId + "  CompanyName:" + item.CompanyName);
            }


        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("CarName :" + item.CarName + "  BrandName:" + item.BrandName + "  ColorName:" + item.ColorName + "  DailyPrice:" + item.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Add(new Brand() { Id = 1, Name = "mercedes" });
            brandManager.Add(new Brand() { Id = 2, Name = "bmw" });
            brandManager.Add(new Brand() { Id = 3, Name = "audi" });

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            brandManager.Delete(new Brand() { Id = 2, Name = "bmw" });
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            brandManager.Update(new Brand() { Id = 3, Name = "toyota" });
            Console.WriteLine("3 nolu marka değiştirilmiştir");
            Console.WriteLine("Id:" + brandManager.GetById(3).Data.Id + "  Name:" + brandManager.GetById(3).Data.Name);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color() { Id = 1, Name = "kırmızı" });
            colorManager.Add(new Color() { Id = 2, Name = "mavi" });
            colorManager.Add(new Color() { Id = 3, Name = "siyah" });

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            colorManager.Delete(new Color() { Id = 2, Name = "mavi" });
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            colorManager.Update(new Color() { Id = 3, Name = "mavi" });
            Console.WriteLine("3 nolu color değiştirilmiştir");
            Console.WriteLine("Id:" + colorManager.GetById(3).Data.Id + "  Name:" + colorManager.GetById(3).Data.Name);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { Id = 16, BrandId = 4, ColorId = 4, DailyPrice = 90, ModelYear = new DateTime(1997, 01, 01), Description = "ÇOCUK" });
            Listele(carManager);
            Console.WriteLine("5 nolu markanın arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
                    ;
            Console.WriteLine("2 nolu rengin arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }

        private static void Listele(CarManager carManager)
        {
            Console.WriteLine("---LIST OF ALL CARS IN MEMORY---");
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }
    }
}
