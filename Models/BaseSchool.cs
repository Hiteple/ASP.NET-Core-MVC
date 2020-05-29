using System;

namespace ASP.Models
{
    public abstract class BaseSchool
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public BaseSchool()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name},{UniqueId}";
        }
    }
}