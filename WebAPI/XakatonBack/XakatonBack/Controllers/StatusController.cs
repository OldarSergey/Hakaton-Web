using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XakatonBack.Model;
using XakatonBack.Services;

namespace XakatonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public List<Status> Get()
        {
            var statuses = _statusService.GetAllStatuses();

           

            return statuses;
        }
    }

    public class StatusData
    {
        public Status Status { get; set; }
        public List<Project> Projects { get; set; }
    }
}
