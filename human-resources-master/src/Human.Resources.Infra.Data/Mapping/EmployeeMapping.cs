using Human.Resources.Domain.Entities;
using Human.Resources.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Human.Resources.Infra.Data.Mapping
{
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.IsActive)
                .IsRequired()
                .HasColumnName("IsActive");

            builder
                .HasOne(c => c.Gender)
                .WithMany(s => s.Employees);

            builder.HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Eduardo Pereira",
                   LastName = "Pereira",
                   Email = "eduardo.ogontijo@gmail.com",
                   BirthDate = new DateTime(1994, 8, 20, 0, 0, 0),
                   GenderId = 1,
                   IsActive = true
               }
            );

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
        }
    }
}
