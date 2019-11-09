namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if(!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=StudentSystem;Integrated Security=true");
			}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(studentCourse =>
                {
                    studentCourse
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });
                    studentCourse
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.CourseEnrollments)
                        .HasForeignKey(sc => sc.StudentId);
                    studentCourse
                        .HasOne(sc => sc.Course)
                        .WithMany(c => c.StudentsEnrolled)
                        .HasForeignKey(sc => sc.CourseId);
                });

            modelBuilder.Entity<Homework>(homework =>
                {
                    homework
                        .HasOne(h => h.Student)
                        .WithMany(s => s.HomeworkSubmissions)
                        .HasForeignKey(h => h.StudentId);
                    homework
                        .HasOne(h => h.Course)
                        .WithMany(c => c.HomeworkSubmissions)
                        .HasForeignKey(h => h.CourseId);
                });

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
