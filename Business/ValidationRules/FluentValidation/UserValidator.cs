using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UId).NotEmpty();
            RuleFor(p => p.userTypeId).NotEmpty();
            RuleFor(p => p.firstName).MinimumLength(2);
            RuleFor(p => p.lastName).MinimumLength(2);
            RuleFor(p=>p.UId).NotNull();
            RuleFor(p => p.status).NotNull();
            RuleFor(p => p.userTypeId).NotNull();
       
            
            
        }
    }
}
