using Human.Resources.Domain.Core.Pagination;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Human.Resources.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<PagedList<EmployeeDto>> GetPagedEmployee(IPagingParams pagingParams);
        Task<IList<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
        Task<Employee> Post(EmployeeDto obj);
        Task<Employee> Put(EmployeeDto obj);
        Task<Employee> PutStatus(EmployeeDto obj);
        void Delete(int id);
    }
}
