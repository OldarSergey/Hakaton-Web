using Microsoft.EntityFrameworkCore;
using XakatonBack.Data;
using XakatonBack.Model;

namespace XakatonBack.Services
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;

        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

      



        public List<Status> GetAllStatuses()
        {
            return _context.Statuses
                .Where(p => p.IsDeleted != true)
                .ToList();
        }

        public string GetPriorityName(int id)
        {
           var priority = _context.Priorities
                .Include(p => p.Projects)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            var priorityName = priority.Name;
            return priorityName;
        }

        public List<Project> GetProjectsForStatus(int statusId)
        {
            return _context.Projects
                .Where(p => p.StatusId == statusId)
                .ToList();
        }

        public bool UpdateProjectStatus(int projectId, int newStatusId)
        {
            
                var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);


                var newStatus = _context.Statuses.FirstOrDefault(s => s.Id == newStatusId);


                // Обновите статус проекта
                project.Status = newStatus;
                project.StatusId = newStatus.Id;

                _context.SaveChanges();
                return true;
            
           
        }
    }
}
