using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    //Bu paketi NuGetten indirdik FluentValidation sınıfnı oluşturduk hangi sınıf için Validation
    //oluşturacağımızı generic olark belirtiyoruz: AbstractValidator<Car> gibi...
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            //Rulefor = ne için kural anlamında ve ne için olduğunu c  kısaltmasıyla belirtip 
            //model adının en az 2 karakter olabileceğini belirttik
            RuleFor(c => c.ModelName).MinimumLength(2);
            
            //Modelname boş olamaz
            RuleFor(c=>c.ModelName).NotEmpty();


            //DailyPrice= Günlük fiyatı boş olamaz
            RuleFor(c => c.DailyPrice).NotEmpty();

            //DailyPrice=günlük fiyatı 0'dan büyük olmak zorunda
            RuleFor(c => c.DailyPrice).GreaterThan(0);


        }
    }
}
