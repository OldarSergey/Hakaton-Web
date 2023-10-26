using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XakatonBack.DTO;
using XakatonBack.Model;
using XakatonBack.Services;

namespace XakatonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public List<Project> Get()
        {
           return _projectService.GetAll();


        }

        [HttpPost]
        public IActionResult Post(InputProject newProject)
        {
            Project project = new Project()
            {
                Name = newProject.Name,
                Description = newProject.Description,
                DeadLine = newProject.DeadLine,
                CategoryId = newProject.CategoryId,
                PriorityId = newProject.PriorityId,
                StatusId = newProject.StatusId
            };

            _projectService.AddProject(project);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            _projectService.DeleteProject(id);

            return Ok();
        }


    }
}
