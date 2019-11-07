using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts;

namespace Tavisca.Tripster.Core
{
    public class RequestValidator:AbstractValidator<Trip>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Mileage).NotNull().NotEmpty().WithMessage("{PropertyName} is Mandatory");
            RuleFor(x => x.Source).NotNull().NotEmpty().WithMessage("{PropertyName} is Mandatory");
            RuleFor(x => x.Stops).NotNull().WithMessage("{PropertyName} is Mandatory");
            RuleFor(x => x.Destination).NotNull().WithMessage("{PropertyName} is Mandatory");
          
        }
       
        // to validate Guid


    }
}
