using TaskManagementSystem.Contexts;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Repositories
{
    public class PriorityRepository(AppDbContext dbcontext) : IPriorityRepository
    {
        private readonly AppDbContext _Dbcontext = dbcontext;
        public IQueryable<PriorityLevel> GetPriotiryLevels() { return _Dbcontext.priorityLevels; }

        public void CreatePriorityLevel(PriorityLevel priorityLevel)
        {
            _Dbcontext.priorityLevels.Add(priorityLevel);
            _Dbcontext.SaveChanges();
        }
        public void UpdatePriorityLevel(PriorityLevel priorityLevel)
        {
            _Dbcontext.priorityLevels.Update(priorityLevel);
            _Dbcontext.SaveChanges();
        }
        public PriorityLevel? GetPriorityLevel(int id)
        {
            return _Dbcontext.priorityLevels.FirstOrDefault(c => c.Id == id);
        }
        public void DeletePriorityLevel(int id)
        {
            var pr = _Dbcontext.priorityLevels.FirstOrDefault(c => c.Id == id);
            if (pr == null) return;
            _Dbcontext.priorityLevels.Remove(pr);
            _Dbcontext.SaveChanges();
        }
    }
}
