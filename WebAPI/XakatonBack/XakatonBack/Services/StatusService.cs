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
                .Include(s => s.Projects) // Загрузите связанные проекты
                .ToList();
        }

        public List<Project> GetProjectsForStatus(int statusId)
        {
            return _context.Projects
                .Where(p => p.StatusId == statusId)
                .ToList();
        }

    }
}
