using System.Collections.Generic;

namespace ReportGenerator.TemplateEditor
{
    public interface ITable
    {
        bool HasHeader { get; }
        int CountRows { get; }
        ITableCells Cells { get; }
        int CountColumns { get; }
        IReadOnlyList<string> Header { get; }
        IReadOnlyList<string> ColumnNames { get; }

        void AddRow();

        void AddRow(int countRow);
    }
}