using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class PriorityLevel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name = null!;
        [Required]
        public int Priority;
    }
}
