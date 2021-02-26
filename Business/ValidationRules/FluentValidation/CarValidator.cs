using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).NotEmpty();
            RuleFor(x => x.CarName).MinimumLength(2);
            RuleFor(x => x.DailyPrice).GreaterThan(0);
        }
    }
}
