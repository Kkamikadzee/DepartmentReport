namespace ReportGenerator.Model
{
    public class Student : Person
    {
        public virtual string TopicOfFinalQualificationWork { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual string BasisOfEducation { get; set; }
    }
}