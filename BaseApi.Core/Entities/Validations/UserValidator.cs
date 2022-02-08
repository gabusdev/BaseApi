using BaseApi.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApi.Core.Validations
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(20);
        }
    }
}
