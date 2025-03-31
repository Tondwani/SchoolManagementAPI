using Microsoft.EntityFrameworkCore;
using AlrightAPI.Interface;
using AlrightAPI.Data;
using AlrightAPI.Models;
using AlrightAPI.NewFolder;

namespace AlrightAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddAsync(Student Student)
        {
            await _context.Students.AddAsync(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task UpdateAsync(Student Student)
        {
            _context.Students.Update(Student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}