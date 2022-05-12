namespace DepartmentReportGenerator.Model
{
    public class Student : Person
    {
        public string TopicOfFinalQualificationWork { get; set; }
        public Teacher Teacher { get; set; }
        public string BasisOfEducation { get; set; }
    }
}