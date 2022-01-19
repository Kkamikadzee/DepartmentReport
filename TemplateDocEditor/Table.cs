using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DepartmentReportGenerator.DocEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class Table: ITable
    {
        private readonly Word.Table _table;
        private readonly bool _hasHeader;
        private readonly TableCells _cells;
        private readonly IReadOnlyList<string> _header;
        private TableColumns _columns;
        
        public bool HasHeader => _hasHeader;
        public int CountRows => _hasHeader ? _table.Rows.Count - 1 : _table.Rows.Count;
        public ITableCells Cells => _cells;
        public int CountColumns => _table.Columns.Count;
        public IReadOnlyList<string> Header => _header;
        public IReadOnlyList<string> ColumnNames => _columns.ColumnNames;

        public Table(Word.Table table, bool? hasHeader = null)
        {
            if ((hasHeader.Equals(true)) && (!HeaderExists(table, out _header)))
            {
                throw new ArgumentException("The table header does not exist.");
            }
            
            _table = table;
            _hasHeader = hasHeader.Equals(true) ? true : false;
            _cells = new TableCells(table, this);
            _columns = new TableColumns(this);
        }

        public void AddRow()
        {
            _table.Rows.Add();
        }
        
        public void AddRow(int countRow)
        {
            for (var i = 0; i < countRow; i++)
            {
                _table.Rows.Add();
            }
        }

        /// <summary>
        /// Проверяет наличие заголовка. Вызывается только в конструкторе до добавления строк.
        /// </summary>
        /// <returns>True - если заголовок есть, иначе false.</returns>
        private bool HeaderExists(Word.Table table, out IReadOnlyList<string> header)
        {
            header = null;
            
            if (table.Rows.Count == 0)
            {
                return false;
            }
            
            var firstRow = new string[_table.Columns.Count];
            for (var i = 0; i < _table.Columns.Count; i++)
            {
                firstRow[i] = _table.Cell(1, i + 1).Range.Text;
            }

            var hasHeader = firstRow.Any(c => !string.IsNullOrEmpty(c));
            if (hasHeader)
            {
                header = firstRow;
            }
            
            return hasHeader;
        }
    }
}