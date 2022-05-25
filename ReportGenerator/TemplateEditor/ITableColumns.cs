using System.Collections.Generic;

namespace ReportGenerator.TemplateEditor
{
    public interface ITableColumns
    {
        IReadOnlyList<string> ColumnNames { get; }
    }
}