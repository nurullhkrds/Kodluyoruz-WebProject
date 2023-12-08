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
    public class CustomerManager : ICustomerService
    {

        ICustomerDal CustomerDal;
        public CustomerManager(ICustomerDal CustomerDal)
        {
            this.CustomerDal = CustomerDal; 
        }


        public IResult Add(Customers entity)
        {
            CustomerDal.Add(entity);
            return new SuccesResult("Eklendi");
        }

        public IResult Delete(Customers entity)
        {
            CustomerDal.Delete(entity);
            return new SuccesResult("Silindi");
        }

        public IDataResult<Customers> Get(int id)
        {
            return new SuccesDataResult<Customers>(CustomerDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccesDataResult<List<Customers>>(CustomerDal.GetAll());
        }

        public IResult Update(Customers entity)
        {
            CustomerDal.Update(entity);
            return new SuccesResult(Messages.Updated);

        }
    }
}
