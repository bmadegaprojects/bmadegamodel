using Human.Resources.Domain.Validators;

namespace Human.Resources.Domain.Entities
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}