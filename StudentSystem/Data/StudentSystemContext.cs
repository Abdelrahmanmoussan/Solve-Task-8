using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    internal class StudentSystemContext : DbContext
    {


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=MOUSSAN\\MSSQLSERVERS;Initial Catalog=StudentSystem ;Integrated Security=True;TrustServerCertificate=True");

    }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Student Class
            modelBuilder.Entity<Student>()
                .Property(n => n.Name)
                .HasColumnType("varchar(80)")
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Student>()
                .Property(pn => pn.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode();

            //Course Class
            modelBuilder.Entity<Course>()
                .Property(n => n.Name)
                .HasColumnType("varchar(80)")
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Course>()
                .Property(d => d.Description)
                .IsUnicode();

            //Resource Class
            modelBuilder.Entity<Resource>()
                .Property(n => n.Name)
                .HasColumnType("varchar(50)")
                .IsUnicode();

            modelBuilder.Entity<Resource>()
                .Property(u => u.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .Property(rt => rt.ResourceType)
                .HasMaxLength(100);
             
            modelBuilder.Entity<Resource>()
                .HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            //StudentCourse Class
            modelBuilder.Entity<StudentCourse>()
        .HasKey(sc => new { sc.StudentId, sc.CourseId }); // Composite key for the mapping table

            base.OnModelCreating(modelBuilder);
        }
    }
}
