using FluentValidation;
using FluentValidation.Results;

namespace Human.Resources.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }
        public abstract bool IsValid();
        public ValidationResult ValidationResult { get; protected set; }
    }
}