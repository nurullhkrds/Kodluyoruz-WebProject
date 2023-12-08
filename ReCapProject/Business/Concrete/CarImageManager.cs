using Business.Abstract;
using Business.Constants;
using Core.Utilities.Bussines;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal carImageDal;
        private readonly IFileHelper fileHelper;
        public CarImageManager(IFileHelper fileHelper, ICarImageDal carImageDal) { 
            this.fileHelper = fileHelper;
            this.carImageDal = carImageDal;
        }


        public IResult Add(IFormFile formFile, CarImage carImage)
        {
           
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result.Succes==false)
            {
                return result;
            }

            
            carImage.ImagePath = fileHelper.Upload(formFile, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            carImageDal.Add(carImage);
            return new SuccesResult("Data Başarıyla yüklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            carImageDal.Delete(carImage);
            return new SuccesResult("Data başarıyla silindi");
        }


        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            carImage.ImagePath=fileHelper.Update(formFile,result,PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            carImageDal.Update(carImage);
            return new SuccesResult("Başarıyla Güncellendi");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>(carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result.Succes==false)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }

            return new SuccesDataResult<List<CarImage>>(carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccesDataResult<CarImage>(carImageDal.Get(c => c.Id == imageId));
        }




        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccesResult();
        }
        private IResult CheckCarImage(int carId)
        {
            var result = carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccesResult();
            }
            return new ErrorResult();
        }


        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "wwwroot\\DefaultImage.jpg" });
            return new SuccesDataResult<List<CarImage>>(carImage);
        }


    }
}
