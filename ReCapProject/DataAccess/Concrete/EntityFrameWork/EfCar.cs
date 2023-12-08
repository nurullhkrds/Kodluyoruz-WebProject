using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCar : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarsDetailDto> GetAllCarsDto()
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.Id equals brand.BrandId
                             join cl in context.Colors on brand.BrandId equals cl.ColorId
                             select new CarsDetailDto
                             {
                                 CarName = car.ModelName,
                                 BrandName = brand.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = car.DailyPrice

                             };
                return result.ToList();

            }
        }
    }
}
