using AlrightAPI.Models;
using AlrightAPI.NewFolder;


namespace AlrightAPI.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();  
        Task<Course> GetByIdAsync(int id);
        Task<Course> AddAsync(Course Course); 
        Task UpdateAsync(Course Course); 
        Task DeleteAsync(int id);
    }
}
