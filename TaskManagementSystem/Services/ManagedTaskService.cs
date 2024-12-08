using TaskManagementSystem.Entities;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Service;

namespace TaskManagementSystem.Services
{
    public class ManagedTaskService(IManagedTaskRepository repository, IPriorityRepository priorityRepository, ICategoryepository categoryepository) : IManagedTaskService
    {
        private readonly IManagedTaskRepository _managedTaskRepository = repository;
        private readonly IPriorityRepository _priorityRepository = priorityRepository;
        private readonly ICategoryepository _categoryepository = categoryepository;

        public IQueryable<ManagedTask> GetManagedTasksByPriority(int priority)
        {
            var Priority = _priorityRepository.GetPriorityLevel(priority);
            if (Priority == null) throw new Exception("Priority not found");
            return _managedTaskRepository.GetAll().Where(t => t.Priority == Priority);
        }
        public IQueryable<ManagedTask> SortTasksByPriority()
        {
            return _managedTaskRepository.GetAll().OrderBy(t => t.Priority.Priority);
        }
    }
}
