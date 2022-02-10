using BaseApi.Common.DTO.Request;
using FluentValidation;

namespace BaseApi.Common.DTO.Request.Validations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(login => login.Email).EmailAddress();
            RuleFor(login => login.Password).NotEmpty();
        }
    }
}
