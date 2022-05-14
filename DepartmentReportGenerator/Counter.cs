namespace DepartmentReportGenerator
{
    public class Counter
    {
        public int Value { get; set; }

        public Counter(int value = 0)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public void Next()
        {
            Value++;
        }
    }
}