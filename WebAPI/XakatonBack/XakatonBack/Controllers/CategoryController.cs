using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XakatonBack.Model;
using XakatonBack.Services;

namespace XakatonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _categoryService.GetAll();
        }
    }
}
