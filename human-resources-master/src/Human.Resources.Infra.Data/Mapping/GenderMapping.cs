using Human.Resources.Domain.Entities;
using Human.Resources.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Human.Resources.Infra.Data.Mapping
{
    public class GenderMapping : EntityTypeConfiguration<Gender>
    {
        public override void Map(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");


            builder.HasData(
                new Gender { Id = 1, Name = "Masculino" },
                new Gender { Id = 2, Name = "Feminino" }
            );

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}
