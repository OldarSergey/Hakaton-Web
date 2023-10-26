using Microsoft.AspNetCore.Mvc;
using XakatonBack.Model;

namespace XakatonBack.Services
{
    public interface IStatusService
    {
       
        public List<Status> GetAllStatuses();
        public List<Project> GetProjectsForStatus(int statusId);
        public string GetPriorityName(int id);
        public bool UpdateProjectStatus(int projectId,int newStatusId);
    }
}
