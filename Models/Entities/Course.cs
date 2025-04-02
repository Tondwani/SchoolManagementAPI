using AlrightAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace AlrightAPI.Models
{
    public class Course
    {
        [Key]
        public required Guid CourseId { get; set; }  
        public required string CourseName { get; set; }
        public required string CourseDescription { get; set; }
        public required Guid CourseIdentifier { get; set; }

        // Central entity for relationships
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}