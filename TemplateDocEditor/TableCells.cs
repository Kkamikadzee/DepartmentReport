using System;
using System.Collections.Generic;
using ReportGenerator.Extension;
using ReportGenerator.TemplateEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class TableCells: ITableCells
    {
        private readonly Word.Table _table;
        private readonly Table _docTable;
        
        public string this[int row, int column]
        {
            get => _table.Cell(_docTable.HasHeader ? row + 2 : row + 1, column + 1).Range.Text;
            set => _table.Cell(_docTable.HasHeader ? row + 2 : row + 1, column + 1).Range.Text = value;
        }

        public string this[int row, string column]
        {
            get => _table.Cell(_docTable.HasHeader ? row + 2 : row + 1, GetColumnIndexByName(column) + 1).Range.Text;
            set => _table.Cell(_docTable.HasHeader ? row + 2 : row + 1, GetColumnIndexByName(column) + 1).Range.Text = value;
        }

        public TableCells(Word.Table table, Table docTable)
        {
            _table = table;
            _docTable = docTable;
        }

        private int GetColumnIndexByName(string columnName)
        {
            int index = _docTable.ColumnNames.IndexOf(columnName);

            if (index == -1)
            {
                throw new IndexOutOfRangeException($"Column with name {columnName} is not found");
            }

            return index;
        }
    }
}