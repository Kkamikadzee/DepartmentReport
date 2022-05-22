using System;
using System.Collections.Generic;

namespace Database.Model
{
    public partial class Person : ReportGenerator.Model.Person
    {
        public Person()
        {
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
