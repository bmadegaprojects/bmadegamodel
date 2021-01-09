using FluentValidation;
using Human.Resources.Domain.Entities;

namespace Human.Resources.Domain.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("É necessário informar o Nome.");

            RuleFor(c => c.LastName)
                .NotNull().WithMessage("É necessário informar o Sobrenome.");

            RuleFor(c => c.Email)
                .NotNull().WithMessage("É necessário informar o Email.");

            RuleFor(c => c.BirthDate)
                .NotNull().WithMessage("É necessário informar a Data de Nascimento.");

            RuleFor(c => c.EmployeeSkills)
                .NotNull().WithMessage("É necessário informar pelo menos uma habilidade.");
        }
    }
}
