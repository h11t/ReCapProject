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
            CarManager carManager = new CarManager(new EFCarDal());
            

            carManager.Add(new Car() { Id = 8, BrandId = 2, ColorId = 1, DailyPrice = 60, ModelYear = new DateTime(1997, 01, 01), Description = "audi" });
            carManager.Add(new Car() { Id = 9, BrandId = 3, ColorId = 1, DailyPrice = 70, ModelYear = new DateTime(1997, 01, 01), Description = "SPOR" });
            carManager.Add(new Car() { Id = 10, BrandId = 5, ColorId = 2, DailyPrice = 80, ModelYear = new DateTime(1997, 01, 01), Description = "KLASİK" });
            carManager.Add(new Car() { Id = 11, BrandId = 5, ColorId = 2, DailyPrice = 90, ModelYear = new DateTime(1997, 01, 01), Description = "ÇOCUK" });
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



            //Car c1=carManager.GetById(1);
            //Console.WriteLine("1 nolu arabanın bilgileri listelenmiştir");
            //Console.WriteLine("Id:" + c1.Id + "   BrandId:" + c1.BrandId + "   ColorId:" + c1.ColorId + "   DailyPrice:" + c1.DailyPrice + "  Description:" + c1.Description + "  ModelYear:" + c1.ModelYear);
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
