using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Interfaces
{
    public interface ISkillService
    {
        Task<IList<SkillDto>> GetAll();
    }
}
