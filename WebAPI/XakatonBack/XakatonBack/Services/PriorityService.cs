using XakatonBack.Data;
using XakatonBack.Model;

namespace XakatonBack.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly ApplicationDbContext _context;

        public PriorityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Priority> GetAll()
        {
            return _context.Priorities
                .Where(p => p.IsDeleted == false)
                .ToList();  
        }
    }
}
