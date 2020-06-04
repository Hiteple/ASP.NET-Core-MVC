using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.Models
{
    public class SchoolContext: DbContext
    {
        // This will be a list of schools (from a table called School). Same for the rest
        public DbSet<School> Schools { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Exam> Exams { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var school = new School();
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.Address = "Viva 7713";
            school.Country = "Bogotá";
            school.City = "Guadalajara";
            school.SchoolType = SchoolType.University;
            school.YearOfCreation = 2005;

            // Populating the table (needs to recieve always array and NOT lists)
            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Subject>().HasData(
                new Subject {Name = "Math", Id = Guid.NewGuid().ToString()},
                new Subject {Name = "Science", Id = Guid.NewGuid().ToString()},
                new Subject {Name = "Spanish", Id = Guid.NewGuid().ToString()}
            );
            modelBuilder.Entity<Student>().HasData(GenerateStudents().ToArray());
        }
        
        private List<Student> GenerateStudents()
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastname1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentList = from n1 in name1
                from n2 in name2
                from a1 in lastname1
                select new Student { Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return studentList.OrderBy((al) => al.Id).ToList();
        }
    }
}