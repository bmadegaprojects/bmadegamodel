using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Interfaces
{
    public interface IGenderService
    {
        Task<IList<GenderDto>> GetAll();
    }
}
