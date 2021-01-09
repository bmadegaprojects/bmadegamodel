using Human.Resources.Domain.Validators;
using System.Collections.Generic;

namespace Human.Resources.Domain.Entities
{
    public class Skill : Entity<Skill>
    {
        public string Name { get; set; }

        public IEnumerable<EmployeeSkill> EmployeeSkills { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new SkillValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}