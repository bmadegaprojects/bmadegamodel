using Human.Resources.Domain.Entities;
using Human.Resources.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Resources.Infra.Data.Mapping
{
    public class SkillMapping : EntityTypeConfiguration<Skill>
    {
        public override void Map(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.HasData(
               new Gender { Id = 1, Name = "C#" },
               new Gender { Id = 2, Name = "Java" },
               new Gender { Id = 3, Name = "Angular" },
               new Gender { Id = 4, Name = "SQL" },
               new Gender { Id = 5, Name = "ASP" }
            );

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}
