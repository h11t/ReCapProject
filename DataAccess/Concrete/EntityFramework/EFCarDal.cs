using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public new  void Add(Car entity)
        {
            if (CheckToAdd(entity))
            {
                using (ReCapContext context=new ReCapContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("ARABA EKLENEMEDİ");
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var results = from car in context.Car
                              join col in context.Color on car.ColorId equals col.Id
                              join br in context.Brand on car.BrandId equals br.Id
                              select new CarDetailDto
                              {
                               CarName=car.Description,
                                BrandName=br.Name,
                                ColorName=col.Name,
                                 DailyPrice=car.DailyPrice
                              };
                return results.ToList();

            }
        }

        public bool CheckToAdd(Car entity)
        {
            if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
