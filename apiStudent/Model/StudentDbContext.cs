using Microsoft.EntityFrameworkCore;

namespace apiStudent.Model
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> StudendTable { get; set; }
    }
}
