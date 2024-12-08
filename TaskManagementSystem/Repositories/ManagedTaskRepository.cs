using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Contexts;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Service
{
    public class ManagedTaskRepository(AppDbContext appDbContext) : IManagedTaskRepository
    {
        private readonly AppDbContext _dbcontext = appDbContext;

        public DbSet<ManagedTask> GetAll() { return _dbcontext.tasks; }

        public ManagedTask? GetById(int id)
        {
            return _dbcontext.tasks.FirstOrDefault(t => t.Id == id);
        }
        public void DeleteById(int id)
        {
            var task = _dbcontext.tasks.FirstOrDefault(task => task.Id == id);
            if (task == null) return;
            _dbcontext.tasks.Remove(task);
            _dbcontext.SaveChanges();
        }
        public void CreateTask(ManagedTask managedTask)
        {
            _dbcontext.tasks.Add(managedTask);
            _dbcontext.SaveChanges();
        }
        public void ModifyTask(ManagedTask managedTask)
        {
            _dbcontext.tasks.Update(managedTask);
            _dbcontext.SaveChanges();
        }
    }
}
