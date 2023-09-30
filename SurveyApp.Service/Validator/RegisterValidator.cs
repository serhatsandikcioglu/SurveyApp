using FluentValidation;
using SurveyApp.Data.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            /*RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("E-Mail cannot be empty");*/
            RuleFor(x => x.Password)
    .NotEmpty().WithMessage("Password cannot be empty")
    .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
    .Matches("[A-Z]").WithMessage("Password must contain uppercase letters")
    .Matches("[a-z]").WithMessage("Password must contain lowercase letters")
    .Matches("[0-9]").WithMessage("Password must contain numbers");
            //RuleFor(x => x.PasswordAgain).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.PasswordAgain).Equal(dto => dto.Password).WithMessage("Passwords must be the same");
        }
    }
}
