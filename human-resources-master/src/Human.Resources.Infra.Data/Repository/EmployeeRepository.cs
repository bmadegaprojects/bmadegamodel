using Human.Resources.Domain.Core.Pagination;
using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using Human.Resources.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human.Resources.Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HumanResourcesContext context) : base(context)
        {
        }

        public async Task<PagedList<Employee>> GetPagedEmployee(IPagingParams pagingParams)
        {
            var query = await _dbSet.AsNoTracking()
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    LastName = e.LastName,
                    Email = e.Email,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    IsActive = e.IsActive,
                    EmployeeSkills = e.EmployeeSkills.Select(s => new EmployeeSkill { Skill = s.Skill }).ToList()
                }).ToPagedListAsync(pagingParams);

            return query;
        }

        public override async Task<IList<Employee>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    LastName = e.LastName,
                    Email = e.Email,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    IsActive = e.IsActive,
                    EmployeeSkills = e.EmployeeSkills.Select(s => new EmployeeSkill { Skill = s.Skill }).ToList()
                }).ToListAsync();
        }

        public override async Task<Employee> GetById(int id)
        {
            return await _dbSet.AsNoTracking()
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    LastName = e.LastName,
                    Email = e.Email,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    IsActive = e.IsActive,
                    EmployeeSkills = e.EmployeeSkills.Select(s => new EmployeeSkill { Skill = s.Skill }).ToList()
                }).Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<bool> UpdateStatus(Employee obj)
        {
            _context.Attach(obj);
            _context.Entry(obj).Property("IsActive").IsModified = true;

            return await _context.SaveChangesAsync() > 0;
        }

        public override async Task<bool> Update(Employee obj)
        {
            var employeeSkills = _context.EmployeeSkills.Where(_ => _.EmployeeId == obj.Id).ToList();

            _context.EmployeeSkills.RemoveRange(employeeSkills);
            _context.EmployeeSkills.AddRange(obj.EmployeeSkills);
            _context.Entry(obj).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
