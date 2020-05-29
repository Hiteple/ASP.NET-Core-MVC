using System;
using System.Collections.Generic;

namespace ASP.Models
{
    public class School:BaseSchool
    {
        public int YearOfCreation { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Address { get; set; }

        public SchoolType SchoolType { get; set; }
        public List<Course> Courses { get; set; }

        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

        public School(string name, int year, 
            SchoolType type, 
            string country = "", string city = "") : base()
        {
            (Name, YearOfCreation) = (name, year);
            Country = country;
            City = city;
        }

        public School()
        {
            
        }

        public override string ToString()
        {
            return $"Name: \"{Name}\", Tipo: {SchoolType} {Environment.NewLine} Country: {Country}, City: {City}";
        }
    }
}