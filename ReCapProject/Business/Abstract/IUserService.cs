﻿using Core.Entities.Concretes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
         
        List<OperationClaim> GetClaims(Users user);
        void Add(Users user);
        Users GetByMail(string email);
    
    }
}
