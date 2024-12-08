using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Repositories
{
    public interface ICategoryepository
    {
        void CreateCatigory(Category category);
        void DeleteCategory(int id);
        IQueryable<Category> GetCategories();
        Category? GetCatigory(int id);
        void UpdateCatigory(Category category);
    }
}