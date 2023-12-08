// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

CarManager manager = new CarManager(new EfCar());
BrandManager bmanager = new BrandManager(new EfBrandDal());






//CarsTest2(manager);

//CarsTest(manager);

static void CarsTest(CarManager manager)
{
    foreach (var car in manager.GetAll().Data)
    {
        Console.WriteLine(car.ModelName);
    }
}

static void CarsTest2(CarManager manager)
{
    foreach (var carsDetails in manager.GetAllCarsDetails().Data)
    {
        Console.WriteLine(carsDetails.CarName + "/ " + carsDetails.BrandName + "/ " + carsDetails.ColorName + "/ " + carsDetails.DailyPrice);
    }
}