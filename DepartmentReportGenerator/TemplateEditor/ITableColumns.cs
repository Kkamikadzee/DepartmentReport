using System.Collections.Generic;

namespace DepartmentReportGenerator.TemplateEditor
{
    public interface ITableColumns
    {
        IReadOnlyList<string> ColumnNames { get; }
    }
}