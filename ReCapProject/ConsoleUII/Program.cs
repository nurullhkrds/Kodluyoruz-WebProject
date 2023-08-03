// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using DataAccess.Concrete;

CarManager manager = new CarManager(new InMemoryCarDal());
foreach (var car in manager.GetAll())
{
    Console.WriteLine(car.ModelYear);
}