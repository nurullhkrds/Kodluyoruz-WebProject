using Core.DataAccess;
using Core.Entities.Concretes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUsersDal:IEntityRepository<Users>
    {

        List<OperationClaim> GetClaims(Users user);
    }
}
