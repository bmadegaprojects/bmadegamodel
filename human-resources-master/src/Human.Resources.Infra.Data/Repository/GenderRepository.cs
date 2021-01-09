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
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(HumanResourcesContext context) : base(context)
        {
        }

        public override async Task<IList<Gender>> GetAll()
        {
            return await _dbSet.Select(e => new Gender
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
