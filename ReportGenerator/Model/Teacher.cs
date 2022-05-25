using System;

namespace ReportGenerator.Model
{
    public class Teacher : Person
    {
        public virtual string ScienceDegree { get; set; }
        public virtual string JobVacancy { get; set; }
    }
}