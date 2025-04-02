using Microsoft.EntityFrameworkCore;
using AlrightAPI.Interface;
using AlrightAPI.Data;
using AlrightAPI.Models.Entities;

namespace AlrightAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }
        public async Task<Teacher?> GetByNationalIDAsync(string nationalIDNumber)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.NationalIDNumber == nationalIDNumber);
        }


        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            // Hash the password before saving it
            teacher.Password = BCrypt.Net.BCrypt.HashPassword(teacher.Password);

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

    }
}