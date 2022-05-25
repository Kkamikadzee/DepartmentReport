namespace ReportGenerator.Exception
{
    public class FileFieldError : System.Exception
    {
        public FileFieldError()
        {
        }

        public FileFieldError(string message)
            : base(message)
        {
        }

        public FileFieldError(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}

