using System;
using System.Collections;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class DocFile : IDisposable
    {
        private readonly Word.Application _application;
        private readonly Word.Document _document;
        private readonly IReadOnlyDictionary<string, DocFileField> _fields;
        private readonly IReadOnlyList<DocFileTable> _tables;

        public IReadOnlyDictionary<string, DocFileField> Fields => _fields;
        public IReadOnlyList<DocFileTable> Tables => _tables;

        public DocFile(string absolutePathFile)
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

        public void SaveAs(string absolutePathFile, DocExtension extension)
        {
            // File.Delete(absolutePathFile);
            _document.SaveAs(FileName: absolutePathFile,
                FileFormat: DocFileUtils.ConvertDocExtensionToWdSaveFormat(extension), 
                ReadOnlyRecommended: true);
        }
        
        private Word.Document ReadDocument(string absolutePathFile)
        {
            return _application.Documents.Open(absolutePathFile, ReadOnly: true);
        }

        private IReadOnlyDictionary<string, DocFileField> FindAllFields()
        {
            Word.Range range = _application.Selection.Range;
            Word.Find find = range.Find;
            
            find.ClearFormatting();
            find.MatchWildcards = true;
            find.Text = DocFileField.FieldExpression;

            find.Execute2007();

            var fields = new Dictionary<string, DocFileField>();
            while (find.Found)
            {
                Word.Range fieldRange = range.Document.Range(range.Start, range.End);
                string field = fieldRange.Text;
                var docFileField = new DocFileField(fieldRange, field);
                fields.Add(docFileField.FieldName, docFileField);
                
                find.Execute2007();
            }

            return fields;
        }

        private IReadOnlyList<DocFileTable> FindAllTables()
        {
            var tables = new DocFileTable[_document.Tables.Count];
            
            var i = 0;
            IEnumerator tableEnumerator = _document.Tables.GetEnumerator();
            while (tableEnumerator.MoveNext())
            {
                tables[i++] = new DocFileTable(tableEnumerator.Current as Word.Table, true);
            }

            return tables;
        }
    }
}