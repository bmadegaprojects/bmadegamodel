using FluentValidation;
using Human.Resources.Domain.Entities;

namespace Human.Resources.Domain.Validators
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull().WithMessage("É necessário informar o Nome.");
        }
    }
}
