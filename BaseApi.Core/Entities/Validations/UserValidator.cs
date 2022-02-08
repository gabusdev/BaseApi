using BaseApi.Core.Entities;
using FluentValidation;

namespace BaseApi.Core.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(20);
        }
    }
}
