using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService:IEntitiyService<Rentals>
    {
        public IResult IsSuitableToRent(Rentals entity);

    }
}
