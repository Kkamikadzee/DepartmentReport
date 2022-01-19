using System.Collections.Generic;

namespace DepartmentReportGenerator.DocEditor
{
    public interface ITableColumns
    {
        IReadOnlyList<string> ColumnNames { get; }
    }
}