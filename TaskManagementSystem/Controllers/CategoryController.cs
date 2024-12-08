using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [Route("/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryepository _categoryepository;

        public CategoryController(ICategoryepository categoryepository)
        {
            _categoryepository = categoryepository;
        }
        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var cat = _categoryepository.GetCatigory(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
        [HttpPost("Create")]
        public IActionResult Create(string title)
        {
            Category category = new();
            category.Title = title;
            _categoryepository.CreateCatigory(category);
            return Ok(category);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            _categoryepository.DeleteCategory(id);
            return Ok();
        }
    }
}
