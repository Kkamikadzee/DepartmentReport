using System;
using System.Collections;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class DocFileTable
    {
        private readonly Word.Table _table;
        private readonly bool _hasHeader;
        private readonly DocFileTableCells _cells;

        public bool HasHeader => _hasHeader;
        public int CountRows => _hasHeader ? _table.Rows.Count - 1 : _table.Rows.Count;
        public DocFileTableCells Cells => _cells;
        public int CountColumns => _table.Columns.Count;

        public IList<string> Header
        {
            get
            {
                if (!_hasHeader)
                {
                    return null;
                }
                
                var header = new string[CountColumns];
                for (var i = 0; i < CountColumns; i++)
                {
                    header[i] = _table.Cell(1, i + 1).Range.Text;
                }

                return header;
            }
        }
        
        public DocFileTable(Word.Table table, bool hasHeader = false)
        {
            if (hasHeader && !HeaderExists(table))
            {
                throw new ArgumentException("The table header does not exist.");
            }
            
            _table = table;
            _hasHeader = hasHeader;
            _cells = new DocFileTableCells(table, hasHeader);
        }

        public void AddRow()
        {
            _table.Rows.Add();
        }

        /// <summary>
        /// Проверяет наличие заголовка. Вызывается только в конструкторе до добавления строк.
        /// </summary>
        /// <returns>True - если заголовок есть, иначе false.</returns>
        private bool HeaderExists(Word.Table table)
        {
            return table.Rows.Count > 0;
        }
    }
}