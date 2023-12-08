using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
            
        }
        public IResult Add(Brand brand)
        {
            brandDal.Add(brand);
            return new Result(true,"Marka Eklendi");
        }

        public IResult Delete(Brand brand)
        {
            brandDal.Delete(brand);
            return new SuccesResult("Başarıyla Silindi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return 
               new DataResult<List<Brand>>(brandDal.GetAll(), true, "Markalar Listelendi");
        }

        public IDataResult<Brand> GetByIdBrand(int brandId)
        {
            return 
               new DataResult<Brand>(brandDal.Get(p=>p.BrandId==brandId), true, "Marka Getirildi");
        }

        public IResult Update(Brand brand)
        {
            brandDal.Update(brand);
            return new Result(true,"Güncelleme Başarılı");
        }
    }
}
