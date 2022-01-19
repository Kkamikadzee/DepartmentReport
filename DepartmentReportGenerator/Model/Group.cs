using System.Collections.Generic;

namespace DepartmentReportGenerator.Model
{
    public class Group
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Course { get; set; }
        public string EducationType { get; set; }
        public string EducationalProgram { get; set; }
        public string SpecialityCode { get; set; }
        public string SpecialityName { get; set; }
        public IReadOnlyList<Student> Students { get; set; }
    }
}