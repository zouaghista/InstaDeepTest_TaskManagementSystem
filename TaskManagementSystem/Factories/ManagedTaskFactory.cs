using TaskManagementSystem.Entities;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Service;

namespace TaskManagementSystem.Factories
{
    public class ManagedTaskFactory(IManagedTaskRepository managedTaskRepository, IPriorityRepository priorityRepository, ICategoryepository catigoryeRepository) : IManagedTaskFactory
    {
        private readonly IManagedTaskRepository _managedTaskRepository = managedTaskRepository;
        private readonly IPriorityRepository _priorityRepository = priorityRepository;
        private readonly ICategoryepository _catigoryeRepository = catigoryeRepository;

        public ManagedTask CreateManagedTask(
            string title,
            string description,
            DateTime dueDate,
            int priorityLevel,
            List<int> categories
            )
        {
            ManagedTask managedTask = new ManagedTask();
            managedTask.Title = title;
            managedTask.Description = description;
            managedTask.DueDate = dueDate;
            PriorityLevel? priotiry = _priorityRepository.GetPriorityLevel(priorityLevel);
            if (priotiry == null) { throw new Exception("Priority not found."); }
            managedTask.Priority = priotiry;
            List<Category> catigoriesToAdd = new();
            foreach (var cat in categories)
            {
                Category? category = _catigoryeRepository.GetCatigory(cat);
                if (category == null) { throw new Exception($"Category of id {cat} is none existant."); }
                catigoriesToAdd.Add(category);
            }
            managedTask.Categories = catigoriesToAdd;
            _managedTaskRepository.CreateTask(managedTask);
            return managedTask;
        }
    }
}
