using System;

namespace DepartmentReportGenerator.Model
{
    public class Teacher : People
    {
        public string ScienceDegree { get; set; }
        public string JobVacancy { get; set; }

        public string ShortNameWithScienceDegreeAndJobVacancy
        {
            get
            {
                if (string.IsNullOrEmpty(ScienceDegree))
                {
                    throw new NullReferenceException("ScienceDegree is null or empty");
                }
                if (string.IsNullOrEmpty(JobVacancy))
                {
                    throw new NullReferenceException("JobVacancy is null or empty");
                }

                return $"{ShortNameWithFirstLastName}, {ScienceDegree}, {JobVacancy}";
            }
        }
    }
}