using System.ComponentModel.DataAnnotations;

namespace AlrightAPI.Models
{
    public class Student
    {
        [Key]
        //public Guid Guid { get; set; } 
        public int StudentId { get; set; } 
        public required string Name { get; set; }
        public required string lastName { get; set; }

        // Reference navigation property
        public int CourseId { get; set; }
        public Course? Course { get; set; }

    }
}
