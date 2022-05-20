namespace DepartmentReportGenerator.TemplateEditor
{
    public interface IField
    {
        string FieldName { get; }
        string Text { get; set; }
    }
}