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
    public class RentalManager : IRentalService
    {
        IRentalsDal rentalsDal;
        public RentalManager(IRentalsDal rentalsDal)
        {
            this.rentalsDal = rentalsDal;
            
        }




        public IResult Add(Rentals entity)
        {
            var result=IsSuitableToRent(entity);
            if (result.Succes)
            {
                rentalsDal.Add(entity);
                return new SuccesResult("Eklendi");
            }
            return new ErrorResult("Rental is not inserted! -- " + result.Message);

        }

        public IResult Delete(Rentals entity)
        {
            rentalsDal.Delete(entity);
            return new SuccesResult("Silindi");

        }

        public IDataResult<Rentals> Get(int id)
        {
            return new SuccesDataResult<Rentals>(rentalsDal.Get(r=>r.Id==id));
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccesDataResult<List<Rentals>>(rentalsDal.GetAll());
        }

      

        public IResult Update(Rentals entity)
        {

            rentalsDal.Update(entity);
            return new SuccesResult("Güncellendi");

        }

        public IResult IsSuitableToRent(Rentals entity)
        {
            var suitable = true;
            List<Rentals> rentals = this.GetAll().Data;
            foreach (Rentals rental in rentals) {
                if (rental.ReturnDate == null)
                {
                    suitable = false;
                }
            }

            return suitable ? new SuccesResult("Rental is suitable")
                : new ErrorResult("Rental is not suitable");

        }

    }
}
