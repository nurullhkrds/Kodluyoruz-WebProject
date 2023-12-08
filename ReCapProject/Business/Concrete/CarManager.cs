using Business.Abstract;
using Business.BussinesAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }



        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        public IResult Add(Car car)
        {
            //Core projesindeki Validation paketnin ValidationTool static sınıfından bir method
            //oluşturduk daha sonra ise parametrelerini(args) oluşturduğumz CarValidator'u ve car sınıfını
            //Atadık böylelikle burada herhangi bir validasyon hatası olursa buradan sonra program duracaktır.
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded); 
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult("Başarıyla Silindi");
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult("Başarıyla Güncellendi");
        }

        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>("Sistem bakımda");

            }
            return new
                DataResult<List<Car>>
                (_carDal.GetAll(), true,"Ürünler Listelendi");

        }
      

        public IDataResult<List<Car>> GetAllByBrand(int brandId)
        {
            return new 
                DataResult<List<Car>>
                (_carDal.GetAll(p => p.BrandId == brandId), true
                ,"Ürünler Listelendi");
                
;        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarsDetailDto>> GetAllCarsDetails()
        {

            return new SuccesDataResult<List<CarsDetailDto>>(_carDal.GetAllCarsDto());
        }

        public IDataResult<List<Car>>  GetAllColor(int ColorId)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == ColorId));
        }

       
    }
}
