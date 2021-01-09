using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using Human.Resources.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human.Resources.Infra.Data.Repository
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(HumanResourcesContext context) : base(context)
        {
        }

        public override async Task<IList<Skill>> GetAll()
        {
            return await _dbSet.Select(e => new Skill
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
