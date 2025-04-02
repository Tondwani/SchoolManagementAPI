using AlrightAPI.Models;
using AlrightAPI.Models.Entities;

namespace AlrightAPI.Interface
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();  
        Task<Teacher> GetByIdAsync(int id); 
        Task<Teacher> AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
        Task<Teacher?> GetByNationalIDAsync(string nationalIDNumber);

    }
}
