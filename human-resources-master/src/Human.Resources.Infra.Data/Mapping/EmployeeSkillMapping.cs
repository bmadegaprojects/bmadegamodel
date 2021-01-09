using Human.Resources.Domain.Entities;
using Human.Resources.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Resources.Infra.Data.Mapping
{
    public class EmployeeSkillMapping : EntityTypeConfiguration<EmployeeSkill>
    {
        public override void Map(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasKey(bc => new { bc.EmployeeId, bc.SkillId });

            builder
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeSkills)
                .HasForeignKey(bc => bc.EmployeeId);

            builder
                .HasOne(bc => bc.Skill)
                .WithMany(c => c.EmployeeSkills)
                .HasForeignKey(bc => bc.SkillId);


            builder.HasData(
               new EmployeeSkill
               {
                   EmployeeId = 1,
                   SkillId = 1
               },
                new EmployeeSkill
                {
                    EmployeeId = 1,
                    SkillId = 3
                }
            );
        }
    }
}
