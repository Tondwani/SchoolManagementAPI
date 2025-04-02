using System.ComponentModel.DataAnnotations;

namespace AlrightAPI.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string? Gender { get; set; }
        public required string NationalIDNumber { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = "Student";

       
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}