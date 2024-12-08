using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [Route("/Priority")]
    public class PriorityController : Controller
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityController(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var prlevel = _priorityRepository.GetPriorityLevel(id);
            if (prlevel == null) return NotFound();
            return Ok(prlevel);
        }
        [HttpPost("Create")]
        public IActionResult Create(string name, int level)
        {
            PriorityLevel priorityLevel = new PriorityLevel();
            priorityLevel.Priority = level;
            priorityLevel.Name = name;
            _priorityRepository.CreatePriorityLevel(priorityLevel);
            return Ok(priorityLevel);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(int id) {
            _priorityRepository.DeletePriorityLevel(id);
            return Ok();
        }
    }
}
