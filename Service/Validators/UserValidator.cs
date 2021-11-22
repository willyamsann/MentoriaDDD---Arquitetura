using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o nome.")
                .NotNull().WithMessage("Por favor insira o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira o email.")
                .NotNull().WithMessage("Por favor insira o email.")
                 .EmailAddress()
                         .WithMessage("Invalido Email Formato.");
        }

    }
}