using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("UserName is required")
               .MaximumLength(200).WithMessage("Firstname is not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("UserName is required")
               .MaximumLength(200).WithMessage("Lastame is not over 200 characters");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required")
                .Length(8, 20).WithMessage("UserName is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not correct")
                .NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .Matches("[A-Z]").WithMessage("Password containt least one number, one uppercase Charactor, one special charactor")
                .Matches("[a-z]").WithMessage("Password containt least one number, one uppercase Charactor, one special charactor")
                .Matches("[0-9]").WithMessage("Password containt least one number, one uppercase Charactor, one special charactor")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password containt least one number, one uppercase Charactor, one special charactor");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Password not equal");
            RuleFor(x => x.PhoneNumber).Length(10).WithMessage("Phone is 10 number");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot geater than 100 years");
        }
    }
}
