namespace ReportGenerator.Exception
{
    public class ReportCreationException : System.Exception
    {
        public ReportCreationException()
        {
        }

        public ReportCreationException(string message)
            : base(message)
        {
        }

        public ReportCreationException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}