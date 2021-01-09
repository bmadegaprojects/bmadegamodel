using AutoMapper;
using Human.Resources.Domain.Core.Notification;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Service.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;
        private readonly DomainNotification _notificationContext;
        private IMapper _mapper;

        public SkillService(ISkillRepository repository, DomainNotification notificationContext, IMapper mapper) 
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _mapper = mapper;
        }

        public async Task<IList<SkillDto>> GetAll()
        {
            var entity = await _repository.GetAll();

            return _mapper.Map<IList<SkillDto>>(entity);
        }
    }
}
