using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Contexts;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Repositories
{
    public class Catigoryepository(AppDbContext dbcontext) : ICategoryepository
    {
        private readonly AppDbContext _Dbcontext = dbcontext;

        public IQueryable<Category> GetCategories() { return _Dbcontext.categories; }

        public void CreateCatigory(Category category)
        {
            _Dbcontext.categories.Add(category);
            _Dbcontext.SaveChanges();
        }
        public void UpdateCatigory(Category category)
        {
            _Dbcontext.categories.Update(category);
            _Dbcontext.SaveChanges();
        }
        public Category? GetCatigory(int id)
        {
            return _Dbcontext.categories.FirstOrDefault(c => c.Id == id);
        }
        public void DeleteCategory(int id)
        {
            var cat = _Dbcontext.categories.FirstOrDefault(c => c.Id == id);
            if (cat == null) return;
            _Dbcontext.categories.Remove(cat);
            _Dbcontext.SaveChanges();
        }
    }
}
