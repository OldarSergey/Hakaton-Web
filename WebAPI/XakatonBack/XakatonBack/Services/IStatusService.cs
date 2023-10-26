using XakatonBack.Model;

namespace XakatonBack.Services
{
    public interface IStatusService
    {
       
        public List<Status> GetAllStatuses();
        public List<Project> GetProjectsForStatus(int statusId);
    }
}
