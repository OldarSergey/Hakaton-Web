using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XakatonBack.DTO;
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
        public List<InputStatusWithProjects>Get()
        {
            var statuses = _statusService.GetAllStatuses();

            var statusesWithProjects = statuses
                .Select(status => new InputStatusWithProjects
                {
                    Id = status.Id,
                    Name = status.Name,
                    Description = status.Description,
                    Projects = _statusService.GetProjectsForStatus(status.Id)

                })
                .ToList();

            return statusesWithProjects;
        }

        


        [HttpPut("{projectId}/{newStatusId}")]
        public IActionResult UpdateProjectStatus(int projectId, int newStatusId)
        {
          
           if(_statusService.UpdateProjectStatus(projectId, newStatusId))
                    return Ok();
            else
            {
                return StatusCode(500);
            }
            
            
           
        }

    }

    
}
