using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XakatonBack.Model;
using XakatonBack.Services;

namespace XakatonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;

        public PriorityController(IPriorityService priorityService, IStatusService statusService)
        {
            _priorityService = priorityService;
            _statusService = statusService;
        }

        [HttpGet]
        public List<Priority> Get()
        {
            return _priorityService.GetAll();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var name = _statusService.GetPriorityName(id);

            return name;
        }
    }
}
