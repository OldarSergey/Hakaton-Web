using XakatonBack.Data;
using XakatonBack.Model;

namespace XakatonBack.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
           return _context.Categories
                .Where(c => c.IsDeleted == false)
                .ToList();
        }
    }
}
