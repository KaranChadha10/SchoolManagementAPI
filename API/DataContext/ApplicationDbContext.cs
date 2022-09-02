using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
