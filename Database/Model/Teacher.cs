using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public partial class Teacher : ReportGenerator.Model.Teacher
    {
        public Teacher()
        {
            Department = new HashSet<Department>();
            Student = new HashSet<Student>();
        }

        public Guid Id { get; set; }
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        
        [NotMapped]
        public override string FirstName
        {
            get => Person.FirstName;
            set => Person.FirstName = value;
        }

        [NotMapped]
        public override string LastName
        {
            get => Person.LastName;
            set => Person.LastName = value;
        }

        [NotMapped]
        public override string Patronymic
        {
            get => Person.Patronymic;
            set => Person.Patronymic = value;
        }
    }
}
