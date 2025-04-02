using AlrightAPI.Models;
using AlrightAPI.NewFolder;

namespace AlrightAPI.Interface
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Returns entities from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllAsync(); 
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(Student Student);
        Task UpdateAsync(Student Student); 
        Task DeleteAsync(int id); 
    }

}
