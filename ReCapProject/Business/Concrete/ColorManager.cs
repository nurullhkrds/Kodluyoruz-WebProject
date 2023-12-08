using Business.Abstract;
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
    public class ColorManager : IColorService
    {

        IColorDal ColorDal;
        public ColorManager(IColorDal ColorDal)
        {
            this.ColorDal = ColorDal;
            
        }


        public IResult Add(Color color)
        {
            ColorDal.Add(color);
            return new Result(true,"Renk Eklendi");
        }

        public IResult Delete(Color color)
        {
            ColorDal.Delete(color);
            return new Result(true, "Renk Silindi");
        }

        public IDataResult<List<Color>> GetAll()
        {
           
            return 
               new SuccesDataResult<List<Color>>(ColorDal.GetAll(),"Renkler Listelendi");


        }

        public IDataResult<Color> GetAllColorById(int colorId)
        {
            return
                new SuccesDataResult<Color>
                (ColorDal.Get(p => p.ColorId == colorId), "Renk Getirildi");
        }

        public IResult Update(Color color)
        {
            ColorDal.Update(color);
            return new Result(true,"Renk Silindi");
        }
    }
}
