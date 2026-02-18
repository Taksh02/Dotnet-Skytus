using System.ComponentModel.DataAnnotations;

namespace assessment8.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int Age { get; set; }
    }
}
