using AlrightAPI.Models;
using AlrightAPI.NewFolder;

namespace AlrightAPI.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();  // Returns entities from the database
        Task<Student> GetByIdAsync(int id);// Get one stuudent 
        Task<Student> AddAsync(Student Student);// add a student to the datbase 
        Task UpdateAsync(Student Student); //  Update student details/info about a student 
        Task DeleteAsync(int id); 
    }

}
