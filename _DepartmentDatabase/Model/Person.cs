using System;
using System.Collections.Generic;

namespace DepartmentDatabase.Model
{
    public partial class Person
    {
        public Person()
        {
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Partonymic { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
