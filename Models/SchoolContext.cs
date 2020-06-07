using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var school = new School();
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.City = "Bogota";
            school.Country = "Colombia";
            school.Address = "Avd Siempre viva";

            // Add courses to school
            var courses = AddCourses(school);

            // Add subjects to each course
            var subjects = AddSubjects(courses);

            // Add students to each course
            var students = AddStudents(courses);

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Course>().HasData(courses.ToArray());
            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());
            modelBuilder.Entity<Student>().HasData(students.ToArray());
        }

        private List<Student> AddStudents(List<Course> cursos)
        {
            var studentsList = new List<Student>();

            Random rnd = new Random();
            foreach (var course in cursos)
            {
                int randomQty = rnd.Next(5, 20);
                var tmplist = GenerateStudents(course, randomQty);
                studentsList.AddRange(tmplist);
            }
            return studentsList;
        }

        private static List<Subject> AddSubjects(List<Course> cursos)
        {
            var fullList = new List<Subject> ();
            foreach (var course in cursos)
            {
                var tmpList = new List<Subject> {
                            new Subject{
                                Id = Guid.NewGuid().ToString(),
                                CourseId = course.Id,
                                Name = "Matemáticas"} ,
                            new Subject{Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Educación Física"},
                            new Subject{Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Castellano"},
                            new Subject{Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Ciencias Naturales"},
                            new Subject{Id = Guid.NewGuid().ToString(), CourseId = course.Id, Name = "Programación"}
                };
                fullList.AddRange(tmpList);
            }

            return fullList;
        }

        private static List<Course> AddCourses(School school)
        {
            return new List<Course>(){
                        new Course() {
                            Id = Guid.NewGuid().ToString(),
                            SchoolId = school.Id,
                            Name = "101" },
                        new Course() {Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "201"},
                        new Course   {Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "301"},
                        new Course() {Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "401"},
                        new Course() {Id = Guid.NewGuid().ToString(), SchoolId = school.Id, Name = "501"},
            };
        }

        private List<Student> GenerateStudents(
            Course course,
            int qty)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastname1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentsList = from n1 in name1
                               from n2 in name2
                               from a1 in lastname1
                               select new Student
                               {
                                   CourseId = course.Id,
                                   Name = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return studentsList.OrderBy((al) => al.Id).Take(qty).ToList();
        }
    }
}