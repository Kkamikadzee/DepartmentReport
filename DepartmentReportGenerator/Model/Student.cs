namespace DepartmentReportGenerator.Model
{
    public class Student : People
    {
        public string TopicOfFinalQualificationWork { get; set; }
        public Teacher Teacher { get; set; }
    }
}