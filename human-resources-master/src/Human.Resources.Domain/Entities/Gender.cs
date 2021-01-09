using Human.Resources.Domain.Validators;
using System.Collections.Generic;

namespace Human.Resources.Domain.Entities
{
    public class Gender : Entity<Gender>
    {
        public string Name { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new GenderValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}