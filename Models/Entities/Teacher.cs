using System.ComponentModel.DataAnnotations;

namespace AlrightAPI.Models.Entities
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string NationalIDNumber { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public string Role { get; set; } = "Teacher";

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}