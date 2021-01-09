using System.Threading.Tasks;
using Human.Resources.Domain.Core.Notification;
using Human.Resources.Domain.Dtos;
using Human.Resources.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Human.Resources.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ApiController
    {
        private readonly ISkillService _service;

        public SkillController(ISkillService service, DomainNotification notification)
            : base(notification)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _service.GetAll());
        }
    }
}
