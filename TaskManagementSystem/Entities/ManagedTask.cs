using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class ManagedTask
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public PriorityLevel Priority { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!;
        public DateTime DueDate { get; set; }

    }
}
