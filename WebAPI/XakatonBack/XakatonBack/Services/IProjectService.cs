using XakatonBack.Model;

namespace XakatonBack.Services
{
    public interface IProjectService
    {
        public void AddProject(Project newProject);
        public Project GetProject(string projectName);
        public void UpdateProject(int id, Project newProject);
        public void DeleteProject(int idProject);
        public List<Project> GetAll();

        //public IEnumerable<Project> GetProjectsSortIdOne();
        //public IEnumerable<Project> GetProjectsSortIdTwo();
        //public IEnumerable<Project> GetProjectsSortIdThree();
        //public Project GetProjectById(int id);
    }
}
