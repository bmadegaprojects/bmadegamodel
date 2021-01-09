using Human.Resources.Domain.Entities;
using Human.Resources.Infra.Data.Extensions;
using Human.Resources.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Human.Resources.Infra.Data.Context
{
    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EmployeeMapping());
            modelBuilder.AddConfiguration(new SkillMapping());
            modelBuilder.AddConfiguration(new GenderMapping());
            modelBuilder.AddConfiguration(new EmployeeSkillMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
