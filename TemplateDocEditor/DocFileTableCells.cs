using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class DocFileTableCells
    {
        private readonly Word.Table _table;
        private readonly bool _hasHeader;

        public string this[int row, int column]
        {
            get => _table.Cell(_hasHeader ? row + 2 : row, column + 1).Range.Text;
            set => _table.Cell(_hasHeader ? row + 2 : row, column + 1).Range.Text = value;
        }

        public DocFileTableCells(Word.Table table, bool hasHeader = false)
        {
            _table = table;
            _hasHeader = hasHeader;
        }
    }
}