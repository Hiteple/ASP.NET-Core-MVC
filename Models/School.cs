using System;
using System.Collections.Generic;

namespace ASP.Models
{
    public class School:BaseSchool
    {
        public string Country { get; set; }
        public string City { get; set; }

        public string Address { get; set; }
        
        public List<Course> Courses { get; set; }

        public School(string name, int year) => (Name) = (name);

        public School(string name, int year, string country = "", string city = "") : base()
        {
            (Name) = (name);
            Country = country;
            City = city;
        }

        public School()
        {
            
        }

        public override string ToString()
        {
            return $"Name: \"{Name}\", Country: {Country}, City: {City}";
        }
    }
}