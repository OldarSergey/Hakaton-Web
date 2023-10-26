using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public void Get()
        {
            Project project = new Project()
            {
                Name = "Второй проект",
                Description = "Описание второго прокта.",
                DeadLine = DateTime.Now,
                CategoryId = 2,
                PriorityId = 1,
                StatusId = 1,
            };
            _projectService.AddProject(project);

            
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            _projectService.DeleteProject(id);

            return Ok();
        }


    }
}
