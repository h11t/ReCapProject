using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Listele(carManager);

            carManager.Add(new Car() { Id = 6, BrandId = 4, ColorId = 2, DailyPrice = 70, ModelYear = new DateTime(1997, 01, 01), Description = "audi" });
            Console.WriteLine("6 nolu araba eklenmiştir.");
            Listele(carManager);

            carManager.Delete(new Car() { Id = 2, BrandId = 1, ColorId = 4, DailyPrice = 30, ModelYear = new DateTime(1993, 01, 01), Description = "nostaljik araba" });
            Console.WriteLine("2 nolu araba silinmiştir");
            Listele(carManager);

            carManager.Update(new Car() { Id = 3, BrandId = 1111, ColorId = 3, DailyPrice = 1520, ModelYear = new DateTime(2021, 01, 01), Description = "araba" });
            Console.WriteLine("3 nolu arabanın bilgileri değiiştirilmiştir");
            Listele(carManager);

            Car c1=carManager.GetById(1);
            Console.WriteLine("1 nolu arabanın bilgileri listelenmiştir");
            Console.WriteLine("Id:" + c1.Id + "   BrandId:" + c1.BrandId + "   ColorId:" + c1.ColorId + "   DailyPrice:" + c1.DailyPrice + "  Description:" + c1.Description + "  ModelYear:" + c1.ModelYear);
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
