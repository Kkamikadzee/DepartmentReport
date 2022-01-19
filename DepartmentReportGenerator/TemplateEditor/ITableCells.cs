namespace DepartmentReportGenerator.DocEditor
{
    public interface ITableCells
    {
        string this[int row, int column] { get; set; }
    }
}