using System.Collections.Generic;

namespace DepartmentReportGenerator.Model
{
    public class Group
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Course { get; set; }
        public DeclinableWord EducationType { get; set; }
        public string EducationalProgram { get; set; }
        public DeclinableWord FormOfEducation { get; set; }
        public string SpecialityCode { get; set; }
        public string SpecialityName { get; set; }
        public IReadOnlyList<Student> Students { get; set; }
        public int AcademicYear { get; set; }

        public string AcademicYearInterval => $"{AcademicYear}/{AcademicYear + 1}";
    }
}