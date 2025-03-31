using Microsoft.EntityFrameworkCore;
using AlrightAPI.Interface;
using AlrightAPI.Data;
using AlrightAPI.Models;
using AlrightAPI.NewFolder;

namespace AlrightAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Course.FindAsync(id);
        }

        public async Task<Course> AddAsync(Course Course)
        {
            await _context.Course.AddAsync(Course);
            await _context.SaveChangesAsync();
            return Course;
        }

        public async Task UpdateAsync(Course Course)
        {
            _context.Course.Update(Course);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}