using System.Linq;
using ReportGenerator.TemplateEditor;

namespace ReportGenerator.Utils
{
    public class TableFiller
    {
        private readonly ITable _table;

        public TableFiller(ITable table)
        {
            _table = table;
        }

        public void FillRowByIndex(int rowIndex, params object[] objs)
        {
            if (_table.CountColumns < rowIndex)
            {
                return;
            }
            
            foreach (var (columnName, index) in _table.ColumnNames.Select((item, index) => (item, index)))
            {
                if (string.IsNullOrEmpty(columnName))
                {
                    _table.Cells[rowIndex, index] = string.Empty;
                    continue;
                }

                _table.Cells[rowIndex, index] = FileFieldHelper.GetFieldValue(columnName, objs);
            }
        }
    }
}