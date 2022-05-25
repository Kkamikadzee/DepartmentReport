using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReportGenerator.Model
{
    public class Group
    {
        public virtual string ShortName { get; set; }
        public virtual int Course { get; set; }
        public virtual DeclinableWord EducationType { get; set; }
        public virtual string EducationalProgram { get; set; }
        public virtual DeclinableWord FormOfEducation { get; set; }
        public virtual string SpecialityCode { get; set; }
        public virtual string SpecialityName { get; set; }
        public virtual int YearOfIssue { get; set; }
        public virtual IReadOnlyCollection<Student> Students { get; set; }

        [IgnoreDataMember]
        public string YearOfIssueInterval => $"{YearOfIssue}/{YearOfIssue + 1}";
    }
}