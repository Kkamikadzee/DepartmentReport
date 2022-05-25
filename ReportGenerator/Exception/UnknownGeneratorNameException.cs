namespace ReportGenerator.Exception
{
    public class UnknownGeneratorNameException : System.Exception
    {
        public UnknownGeneratorNameException()
        {
        }

        public UnknownGeneratorNameException(string message)
            : base(message)
        {
        }

        public UnknownGeneratorNameException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}