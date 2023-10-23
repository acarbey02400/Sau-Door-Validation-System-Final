using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DoorRoleValidator:AbstractValidator<DoorRole>
    {
        public DoorRoleValidator()
        {
            RuleFor(p => p.id).NotEmpty();
            RuleFor(p => p.doorId).NotEmpty();
            RuleFor(p=>p.userTypeId).NotEmpty();
            RuleFor(p=>p.name).NotEmpty();
        }
    }
}
