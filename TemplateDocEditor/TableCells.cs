using System.Collections.Generic;
using DepartmentReportGenerator.DocEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class TableCells: ITableCells
    {
        private readonly Word.Table _table;
        private readonly Table _docTable;
        
        public string this[int row, int column]
        {
            get => _table.Cell(_docTable.HasHeader ? row + 2 : row, column + 1).Range.Text;
            set => _table.Cell(_docTable.HasHeader ? row + 2 : row, column + 1).Range.Text = value;
        }

        public TableCells(Word.Table table, Table docTable)
        {
            _table = table;
            _docTable = docTable;
        }
    }
}