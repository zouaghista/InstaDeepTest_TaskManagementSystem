using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Factories;
using TaskManagementSystem.Service;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("/Task")]
    public class ManagedTaskController : Controller
    {
        private readonly IManagedTaskService _managedTaskService;
        private readonly IManagedTaskRepository _managedTaskRepository;
        private readonly IManagedTaskFactory _managedTaskFactory;

        public ManagedTaskController(IManagedTaskService managedTaskService, IManagedTaskFactory managedTaskFactory, IManagedTaskRepository managedTaskRepository)
        {
            _managedTaskService = managedTaskService;
            _managedTaskFactory = managedTaskFactory;
            _managedTaskRepository = managedTaskRepository;
        }

        [HttpGet("Get")]
        public IActionResult GetTask(int id)
        {
            var task = _managedTaskRepository.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost("Create")]
        public IActionResult CreateTask(string title, string description, DateTime dueDate, int priorityLevel, List<int> categories)
        {
            try
            {
                var task = _managedTaskFactory.CreateManagedTask(
                    title, description, dueDate, priorityLevel, categories
                    );
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Delete")]
        public IActionResult DeleteTask(int id) {
            _managedTaskRepository.DeleteById(id);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult UpdateTask(ManagedTask task) {
            _managedTaskRepository.ModifyTask(task);
            return Ok();
        }
        [HttpGet("GetByDueDate")]
        public IActionResult GetByDueDate(DateTime dueDate) {
            return Ok(_managedTaskRepository.GetAll().Where(e=>e.DueDate == dueDate));
        }
        [HttpGet("GetByCatigory")]
        public IActionResult GetByCatigory(int cat)
        {
            return Ok(_managedTaskRepository.GetAll().Where(e => e.Categories.Any(e=>e.Id==cat)));
        }
    }
}
