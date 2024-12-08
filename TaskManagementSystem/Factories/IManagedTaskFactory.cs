using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Factories
{
    public interface IManagedTaskFactory
    {
        ManagedTask CreateManagedTask(string title, string description, DateTime dueDate, int priorityLevel, List<int> categories);
    }
}