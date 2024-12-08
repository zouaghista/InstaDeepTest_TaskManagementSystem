using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Service
{
    public interface IManagedTaskRepository
    {
        void CreateTask(ManagedTask managedTask);
        void DeleteById(int id);
        DbSet<ManagedTask> GetAll();
        ManagedTask? GetById(int id);
        void ModifyTask(ManagedTask managedTask);
    }
}