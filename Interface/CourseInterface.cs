using AlrightAPI.Models;
using AlrightAPI.NewFolder;


namespace AlrightAPI.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();  // Returns entities from the database
        Task<Course> GetByIdAsync(int id);// Get one stuudent 
        Task<Course> AddAsync(Course Course);// add a student to the datbase 
        Task UpdateAsync(Course Course); //  Update student details/info about a student 
        Task DeleteAsync(int id);
    }
}
