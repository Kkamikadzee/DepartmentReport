namespace DepartmentReportGenerator.DocEditor
{
    public interface IField
    {
        string FieldName { get; }
        string Text { get; set; }
    }
}