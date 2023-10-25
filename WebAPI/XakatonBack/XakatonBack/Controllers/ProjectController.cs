using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XakatonBack.Model;
using XakatonBack.Services;

namespace XakatonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var projects = _projectService.GetAll();
            return projects;
        }

        [HttpPost]
        public IActionResult Post(Project project)
        {
            //Project project = new Project()
            //{
            //    Name = "Второй проект",
            //    Description = "Описание второго прокта",
            //    DeadLine = DateTime.Now,
            //    CategoryId = 2,
            //    PriorityId = 1,
            //    StatusId = 3,
            //};
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
