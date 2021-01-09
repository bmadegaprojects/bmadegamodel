using AutoMapper;
using Human.Resources.Domain.Core.Notification;
using Human.Resources.Domain.Core.Pagination;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using Human.Resources.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human.Resources.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly DomainNotification _notificationContext;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, DomainNotification notificationContext, IMapper mapper)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _mapper = mapper;
        }

        public async Task<PagedList<EmployeeDto>> GetPagedEmployee(IPagingParams pagingParams)
        {
            var entity = await _repository.GetPagedEmployee(pagingParams);

            return new PagedList<EmployeeDto>(
                entity.PageItems.Select(_ => _mapper.Map<EmployeeDto>(_)).ToList(),
                entity.TotalItems,
                pagingParams
                );
        }

        public async Task<IList<EmployeeDto>> GetAll()
        {
            var entity = await _repository.GetAll();

            return _mapper.Map<IList<EmployeeDto>>(entity);
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task<Employee> Post(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);

            if (!entity.IsValid())
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return entity;
            }

            await _repository.Insert(entity);
            return entity;
        }

        public async Task<Employee> Put(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);

            if (!entity.IsValid())
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return entity;
            }

            await _repository.Update(entity);
            return entity;
        }

        public async Task<Employee> PutStatus(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);

            if (!entity.IsValid())
            {
                _notificationContext.AddNotifications(entity.ValidationResult);
                return entity;
            }

            await _repository.UpdateStatus(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
