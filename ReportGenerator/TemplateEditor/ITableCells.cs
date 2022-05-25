namespace ReportGenerator.TemplateEditor
{
    public interface ITableCells
    {
        string this[int row, int column] { get; set; }
        
        string this[int row, string column] { get; set; }
    }
}