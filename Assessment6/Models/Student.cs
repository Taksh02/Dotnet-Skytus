using System.ComponentModel.DataAnnotations;

namespace Assessment6.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Course { get; set; }

        [Range(0, 100)]
        public int Marks { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }   // ✅ ADD THIS LINE
    }
}
