using AutoMapper;
using Human.Resources.Domain.Core.Notification;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Service.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;
        private readonly DomainNotification _notificationContext;
        private IMapper _mapper;

        public GenderService(IGenderRepository repository, DomainNotification notificationContext, IMapper mapper) 
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _mapper = mapper;
        }

        public async Task<IList<GenderDto>> GetAll()
        {
            var entity = await _repository.GetAll();

            return _mapper.Map<IList<GenderDto>>(entity);
        }
    }
}
