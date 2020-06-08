using System;

namespace ASP.Models
{
    public abstract class BaseSchool
    {
        public string Id { get; set; }
        public virtual string Name { get; set; }

        public BaseSchool()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name},{Id}";
        }
    }
}