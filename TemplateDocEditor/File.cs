using System;
using System.Collections;
using System.Collections.Generic;
using DepartmentReportGenerator.TemplateEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class File : IFile, IDisposable
    {
        private readonly Word.Application _application;
        private readonly Word.Document _document;
        private readonly IReadOnlyDictionary<string, IField> _fields;
        private readonly IReadOnlyList<ITable> _tables;

        public IReadOnlyDictionary<string, IField> Fields => _fields;
        public IReadOnlyList<ITable> Tables => _tables;

        public File(string absolutePathFile)
        {
            _application = new Word.ApplicationClass();
            _document = ReadDocument(absolutePathFile);
            _fields = FindAllFields();
            _tables = FindAllTables();
        }

        public void Dispose()
        {
            _document.Close(false);
            _application.Quit(false);
        }

        public void SaveAs(string absolutePathFile, Extension extension)
        {
            // File.Delete(absolutePathFile);
            _document.SaveAs(FileName: absolutePathFile,
                FileFormat: Utils.ConvertDocExtensionToWdSaveFormat(extension), 
                ReadOnlyRecommended: true);
        }
        
        private Word.Document ReadDocument(string absolutePathFile)
        {
            return _application.Documents.Open(absolutePathFile, ReadOnly: true);
        }

        private IReadOnlyDictionary<string, IField> FindAllFields()
        {
            Word.Range range = _application.Selection.Range;
            Word.Find find = range.Find;
            
            find.ClearFormatting();
            find.MatchWildcards = true;
            find.Text = Field.FieldExpression;

            find.Execute2007();

            var fields = new Dictionary<string, IField>();
            while (find.Found)
            {
                Word.Range fieldRange = range.Document.Range(range.Start, range.End);
                string field = fieldRange.Text;
                var docFileField = new Field(fieldRange, field);
                fields.Add(docFileField.FieldName, docFileField);
                
                find.Execute2007();
            }

            return fields;
        }

        private IReadOnlyList<ITable> FindAllTables()
        {
            var tables = new Table[_document.Tables.Count];
            
            var i = 0;
            IEnumerator tableEnumerator = _document.Tables.GetEnumerator();
            while (tableEnumerator.MoveNext())
            {
                tables[i++] = new Table(tableEnumerator.Current as Word.Table);
            }

            return tables;
        }
    }
}