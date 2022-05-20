using System;
using System.Collections.Generic;

namespace DepartmentDatabase.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            Department = new HashSet<Department>();
            Student = new HashSet<Student>();
        }

        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string ScienceDegree { get; set; }
        public string JobVacancy { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
