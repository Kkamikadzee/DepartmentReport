using System;
using System.Collections.Generic;

namespace DepartmentDatabase.Model
{
    public partial class Student
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid TeacherId { get; set; }
        public string TopicOfFinalQualificationWork { get; set; }
        public string BasicOfEducation { get; set; }

        public virtual Person Person { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
