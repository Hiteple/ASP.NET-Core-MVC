using System;

namespace ASP.Models
{
    public class Exams
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public Student Student { get; set; }
        public Subject Subject  { get; set; }

        public float Grade { get; set; }

        public Exams() => UniqueId = Guid.NewGuid().ToString();
    }
}