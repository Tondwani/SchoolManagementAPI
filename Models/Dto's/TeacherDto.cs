using AlrightAPI.NewFolder;

namespace AlrightAPI.Models.Dto_s
{
    

    public class TeacherDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string NationalIDNumber { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }

        public required CourseDto Course { get; set; }
    }
}
