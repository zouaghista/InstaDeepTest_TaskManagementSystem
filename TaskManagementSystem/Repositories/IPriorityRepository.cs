using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Repositories
{
    public interface IPriorityRepository
    {
        void CreatePriorityLevel(PriorityLevel priorityLevel);
        void DeletePriorityLevel(int id);
        IQueryable<PriorityLevel> GetPriotiryLevels();
        PriorityLevel? GetPriorityLevel(int id);
        void UpdatePriorityLevel(PriorityLevel priorityLevel);
    }
}