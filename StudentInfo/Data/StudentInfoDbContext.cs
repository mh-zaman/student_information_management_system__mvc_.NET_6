using Microsoft.EntityFrameworkCore;
using StudentInfo.Models.Domain;
namespace StudentInfo.Data
{
    public class StudentInfoDbContext : DbContext
    {
        public StudentInfoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)               // Student has one Class
                .WithMany(c => c.Students)          // Class has many Students
                .HasForeignKey(s => s.ClassId);    // Foreign key is ClassId
        }
    }
}
