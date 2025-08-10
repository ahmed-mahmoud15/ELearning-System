//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace ELearning_System.Models;

//public partial class OnlineLearningSystemContext : DbContext
//{
//    public OnlineLearningSystemContext()
//    {
//    }

//    public OnlineLearningSystemContext(DbContextOptions<OnlineLearningSystemContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

//    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

//    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

//    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

//    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

//    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

//    public virtual DbSet<Certificate> Certificates { get; set; }

//    public virtual DbSet<Course> Courses { get; set; }

//    public virtual DbSet<Enrollment> Enrollments { get; set; }

//    public virtual DbSet<Follow> Follows { get; set; }

//    public virtual DbSet<Instructor> Instructors { get; set; }

//    public virtual DbSet<Lesson> Lessons { get; set; }

//    public virtual DbSet<Like> Likes { get; set; }

//    public virtual DbSet<Payment> Payments { get; set; }

//    public virtual DbSet<Student> Students { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<AspNetRole>(entity =>
//        {
//            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
//                .IsUnique()
//                .HasFilter("([NormalizedName] IS NOT NULL)");

//            entity.Property(e => e.Name).HasMaxLength(256);
//            entity.Property(e => e.NormalizedName).HasMaxLength(256);
//        });

//        modelBuilder.Entity<AspNetRoleClaim>(entity =>
//        {
//            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

//            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
//        });

//        modelBuilder.Entity<AspNetUser>(entity =>
//        {
//            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

//            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
//                .IsUnique()
//                .HasFilter("([NormalizedUserName] IS NOT NULL)");

//            entity.Property(e => e.Email).HasMaxLength(256);
//            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
//            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
//            entity.Property(e => e.UserName).HasMaxLength(256);

//            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
//                .UsingEntity<Dictionary<string, object>>(
//                    "AspNetUserRole",
//                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
//                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
//                    j =>
//                    {
//                        j.HasKey("UserId", "RoleId");
//                        j.ToTable("AspNetUserRoles");
//                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
//                    });
//        });

//        modelBuilder.Entity<AspNetUserClaim>(entity =>
//        {
//            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<AspNetUserLogin>(entity =>
//        {
//            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

//            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<AspNetUserToken>(entity =>
//        {
//            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

//            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
//        });

//        modelBuilder.Entity<Certificate>(entity =>
//        {
//            entity.HasIndex(e => e.EnrollmentId, "IX_Certificates_EnrollmentId");

//            entity.HasOne(d => d.Enrollment).WithMany(p => p.Certificates).HasForeignKey(d => d.EnrollmentId);
//        });

//        modelBuilder.Entity<Course>(entity =>
//        {
//            entity.HasIndex(e => e.CreationDate, "IX_Courses_CreationDate");

//            entity.HasIndex(e => e.InstructorId, "IX_Courses_InstructorId");

//            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses).HasForeignKey(d => d.InstructorId);
//        });

//        modelBuilder.Entity<Enrollment>(entity =>
//        {
//            entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseId");

//            entity.HasIndex(e => e.Date, "IX_Enrollments_Date");

//            entity.HasIndex(e => e.PaymentId, "IX_Enrollments_PaymentId");

//            entity.HasIndex(e => e.Progress, "IX_Enrollments_Progress");

//            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "IX_Enrollments_StudentId_CourseId").IsUnique();

//            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//            entity.HasOne(d => d.Payment).WithMany(p => p.Enrollments)
//                .HasForeignKey(d => d.PaymentId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        modelBuilder.Entity<Follow>(entity =>
//        {
//            entity.HasKey(e => new { e.StudentId, e.InstructorId });

//            entity.HasIndex(e => e.InstructorId, "IX_Follows_InstructorId");

//            entity.HasOne(d => d.Instructor).WithMany(p => p.Follows)
//                .HasForeignKey(d => d.InstructorId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//            entity.HasOne(d => d.Student).WithMany(p => p.Follows)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        modelBuilder.Entity<Instructor>(entity =>
//        {
//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Instructor).HasForeignKey<Instructor>(d => d.Id);
//        });

//        modelBuilder.Entity<Lesson>(entity =>
//        {
//            entity.HasIndex(e => e.CourseId, "IX_Lessons_CourseId");

//            entity.HasIndex(e => e.SequenceNumber, "IX_Lessons_SequenceNumber");

//            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        modelBuilder.Entity<Like>(entity =>
//        {
//            entity.HasKey(e => new { e.StudentId, e.CourseId });

//            entity.HasIndex(e => e.CourseId, "IX_Likes_CourseId");

//            entity.HasOne(d => d.Course).WithMany(p => p.Likes)
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//            entity.HasOne(d => d.Student).WithMany(p => p.Likes)
//                .HasForeignKey(d => d.StudentId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        modelBuilder.Entity<Payment>(entity =>
//        {
//            entity.HasIndex(e => e.PaymentDate, "IX_Payments_PaymentDate");
//        });

//        modelBuilder.Entity<Student>(entity =>
//        {
//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Student).HasForeignKey<Student>(d => d.Id);
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasIndex(e => e.IdentityId, "IX_Users_IdentityId");

//            entity.HasOne(d => d.Identity).WithMany(p => p.Users).HasForeignKey(d => d.IdentityId);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
