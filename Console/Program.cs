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
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetCarDetails())
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

            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            brandManager.Delete(new Brand() { Id = 2, Name = "bmw" });
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            brandManager.Update(new Brand() { Id = 3, Name = "toyota" });
            Console.WriteLine("3 nolu marka değiştirilmiştir");
            Console.WriteLine("Id:" + brandManager.GetById(3).Id + "  Name:" + brandManager.GetById(3).Name);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color() { Id = 1, Name = "kırmızı" });
            colorManager.Add(new Color() { Id = 2, Name = "mavi" });
            colorManager.Add(new Color() { Id = 3, Name = "siyah" });

            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            colorManager.Delete(new Color() { Id = 2, Name = "mavi" });
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.Name);
            }

            colorManager.Update(new Color() { Id = 3, Name = "mavi" });
            Console.WriteLine("3 nolu color değiştirilmiştir");
            Console.WriteLine("Id:" + colorManager.GetById(3).Id + "  Name:" + colorManager.GetById(3).Name);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { Id = 16, BrandId = 4, ColorId = 4, DailyPrice = 90, ModelYear = new DateTime(1997, 01, 01), Description = "ÇOCUK" });
            Listele(carManager);
            Console.WriteLine("5 nolu markanın arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByBrandId(5))
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
                    ;
            Console.WriteLine("2 nolu rengin arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }

        private static void Listele(CarManager carManager)
        {
            Console.WriteLine("---LIST OF ALL CARS IN MEMORY---");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }
    }
}
