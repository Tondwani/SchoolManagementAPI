using AlrightAPI.Models;

namespace AlrightAPI.NewFolder
{
    public class StudentDto
    {

        public required string Name { get; set; }
        public required string lastName { get; set; }

        public required CourseDto Course { get; set; }
    }
}
