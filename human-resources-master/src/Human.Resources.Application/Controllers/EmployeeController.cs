using System.Threading.Tasks;
using Human.Resources.Domain.Core.Notification;
using Human.Resources.Domain.Core.Pagination;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Human.Resources.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service, DomainNotification notification)
            : base(notification)
        {
            _service = service;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] PagingParams pagingParams)
        {
            return Response(await _service.GetPagedEmployee(pagingParams));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Response(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto item)
        {
            await _service.Post(item);
            return Response(item);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeDto item)
        {
            await _service.Put(item);
            return Response(item);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] EmployeeDto item)
        {
            await _service.PutStatus(item);
            return Response(item);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Response();
        }
    }
}
