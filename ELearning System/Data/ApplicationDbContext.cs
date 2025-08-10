using ELearning_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELearning_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public  DbSet<Certificate> Certificates { get; set; }

        public  DbSet<Course> Courses { get; set; }

        public  DbSet<Enrollment> Enrollments { get; set; }

        public  DbSet<Follow> Follows { get; set; }

        public  DbSet<Instructor> Instructors { get; set; }

        public  DbSet<Lesson> Lessons { get; set; }

        public  DbSet<Like> Likes { get; set; }

        public  DbSet<Payment> Payments { get; set; }

        public  DbSet<Student> Students { get; set; }

        public  DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Follow>().HasKey(e => new {e.StudentId, e.InstructorId});
            builder.Entity<Like>().HasKey(e => new {e.StudentId, e.CourseId});
            //builder.Entity<User>(b =>
            //{
            //    b.HasKey(u => u.Id);
            //    b.Property(u => u.Id).ValueGeneratedNever(); // value comes from AspNetUsers.Id

            //    b.HasOne<IdentityUser>()              // principal type
            //     .WithOne()                           // IdentityUser has no navigation back
            //     .HasForeignKey<User>(u => u.Id)     // User.Id is FK
            //     .HasPrincipalKey<IdentityUser>(iu => iu.Id)
            //     .OnDelete(DeleteBehavior.Cascade);
            //});

        }
        }
    }
