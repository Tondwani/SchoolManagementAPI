using AlrightAPI.Models;

namespace AlrightAPI.NewFolder
{
    public class StudentDto
    {

        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string? Gender { get; set; }
        public required string NationalIDNumber { get; set; }
        public required string Password { get; set; }

        public required CourseDto Course { get; set; }
    }
}
