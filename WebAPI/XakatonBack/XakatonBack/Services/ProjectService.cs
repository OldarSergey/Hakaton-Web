using Microsoft.EntityFrameworkCore;
using XakatonBack.Data;
using XakatonBack.Model;

namespace XakatonBack.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProject(Project newProject)
        {
            var chat = new Chat
            {
                Users = _context.Projects
                            .Include(p => p.Users)
                            .FirstOrDefault(p => p.Id == newProject.Id)
                            ?.Users.ToList() 
            };
            _context.Chats.Add(chat);
            _context.SaveChanges();

            var lastChat = _context.Chats
                .Where(c => c.IsDeleted == false)
                .OrderBy(c => c.Id)
                .LastOrDefault();

            newProject.ChatId = lastChat.Id;

            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public void DeleteProject(int idProject)
        {
            var project = _context.Projects
                .Where(p => p.Id == idProject)
                .FirstOrDefault();
            project.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return _context.Projects
                .Where (p => p.IsDeleted != true)
                .Include(p => p.Tasks)
                .Include(p => p.Status)
                .Include(p => p.Users)
                .ToList();
        }

        public Project GetProject(string projectName)
        {
            return _context.Projects
                .Where(p => p.Name == projectName && p.IsDeleted == false)
                .FirstOrDefault();
        }
        public void UpdateProject(int id, Project newProject)
        {
            var project = _context.Projects
                 .Where(pr => pr.Id == id)
                 .FirstOrDefault();
            project.IsDeleted = true;

            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        //public IEnumerable<Project> GetProjectsSortIdOne()
        //{
        //    return _context.Projects
        //        .Where(pr => pr.IsDeleted == false && pr.StatusId == 1)

        //        .ToList();
        //}

        //public IEnumerable<Project> GetProjectsSortIdTwo()
        //{
        //    return _context.Projects
        //        .Where(pr => pr.IsDeleted == false && pr.StatusId == 2)
        //        .Include(pr => pr.Priority)
        //        .Include(pr => pr.Team)
        //        .ToList();
        //}


        //public IEnumerable<Project> GetProjectsSortIdThree()
        //{
        //    return _context.Projects
        //        .Where(pr => pr.IsDeleted == false && pr.StatusId == 3)
        //        .Include(pr => pr.Priority)
        //        .Include(pr => pr.Team)
        //        .ToList();
        //}



        //public Project GetProjectById(int id)
        //{
        //    return _context.Projects
        //         .Where(p => p.Id == id && p.IsDeleted == false)
        //         .Include(pr => pr.Priority)
        //         .Include(pr => pr.Team)
        //         .FirstOrDefault();
        //}
    }
}
