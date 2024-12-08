using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Services
{
    public interface IManagedTaskService
    {
        IQueryable<ManagedTask> GetManagedTasksByPriority(int priority);
        IQueryable<ManagedTask> SortTasksByPriority();
    }
}