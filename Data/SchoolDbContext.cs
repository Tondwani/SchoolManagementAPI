using AlrightAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AlrightAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
