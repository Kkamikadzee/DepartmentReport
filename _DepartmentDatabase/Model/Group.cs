using System;
using System.Collections.Generic;

namespace DepartmentDatabase.Model
{
    public partial class Group
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string ShortName { get; set; }
        public int Course { get; set; }
        public string EducationType { get; set; }
        public string EducationalProgram { get; set; }
        public string FormOfEducation { get; set; }
        public string SpecialityCode { get; set; }
        public string SpecialityName { get; set; }
        public int YearOfIssue { get; set; }

        public virtual Department Department { get; set; }

        //public virtual ICollection<Student> Student { get; set; }
    }
}
