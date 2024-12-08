using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public List<ManagedTask> Tasks { get; set; } = null!;
    }
}
