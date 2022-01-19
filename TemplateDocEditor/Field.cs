using DepartmentReportGenerator.DocEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class Field: IField
    {
        public const string FieldExpression = @"\[$?*$\]";
        
        private readonly Word.Range _range;
        private readonly string _field;
        private readonly string _fieldName;

        public string FieldName => _fieldName;
        public string Text
        {
            get => _range.Text;
            set => _range.Text = value;
        }

        public Field(Word.Range range, string field)
        {
            _range = range;
            _field = field;
            _fieldName = field.Substring(2, field.Length - 4);
        }
    }
}