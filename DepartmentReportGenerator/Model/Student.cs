namespace DepartmentReportGenerator.Model
{
    public class Student : Person
    {
        public string TopicOfFinalQualificationWork { get; set; }
        public Teacher Teacher { get; set; }
    }
}