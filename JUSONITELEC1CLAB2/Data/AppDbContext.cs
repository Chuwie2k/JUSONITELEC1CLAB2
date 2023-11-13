using JUSONITELEC1CLAB2.Models;
using Microsoft.EntityFrameworkCore;

namespace JUSONITELEC1CLAB2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Cassandra",
                    Course = Course.BSIT,
                    DateEnrolled = DateTime.Parse("8/12/2002")
                },
                new Student()
                {
                    Id = 2,
                    Name = "Cassandra",
                    Course = Course.BSCS,
                    DateEnrolled = DateTime.Parse("8/12/2002")
                },
                new Student()
                {
                    Id = 3,
                    Name = "Cassandra",
                    Course = Course.BSIS,
                    DateEnrolled = DateTime.Parse("8/12/2002")
                }
                    );
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Vince Albert",
                    LastName = "Juson",
                    Rank = Rank.Professor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("8/12/2002")
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Cassandra",
                    LastName = "Lugtu",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("8/12/2002")
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Colbie",
                    LastName = "Lugtu",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("8/12/2002")
                });

        }

    }
}
