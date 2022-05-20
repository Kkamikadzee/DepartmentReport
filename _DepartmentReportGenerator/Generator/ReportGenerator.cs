using System.Collections.Generic;
using System.Linq;
using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;
using DepartmentReportGenerator.Utils;

namespace DepartmentReportGenerator.Generator
{
    public abstract class ReportGenerator
    {
        public IFile Generate(IFile file, Document document)
        {
            FillObjectInfo(file, document);

            FillOtherInfo(file, document);

            return file;
        }

        protected abstract void FillOtherInfo(IFile file, Document document);

        protected void FillInfoInTable<T>(ITable table, IReadOnlyCollection<T> objectPerRow,
            int rowCounterStart = 0, params object[] otherObjectsForFilling)
        {
            if (table.CountRows < objectPerRow.Count())
            {
                table.AddRow(objectPerRow.Count() - table.CountRows);
            }
            
            var tableFiller = new TableFiller(table);
            
            var objectsForRow = new object[otherObjectsForFilling.Length + 2];
            for (var i = 0; i < otherObjectsForFilling.Length; ++i)
            {
                objectsForRow[i + 2] = otherObjectsForFilling[i];
            }

            var rowCounter = new Counter(rowCounterStart);
            foreach (var (rowInfo, index) in objectPerRow.Select((item, index) => (item, index)))
            {
                objectsForRow[0] = rowCounter;
                objectsForRow[1] = rowInfo;
                
                tableFiller.FillRowByIndex(index, objectsForRow);
                rowCounter.Next();
            }
        }

        private void FillObjectInfo(IFile file, object obj)
        {
            foreach (string fieldName in file.Fields.Keys)
            {
                file.Fields[fieldName].Text = FileFieldHelper.GetFieldValue(fieldName, obj);
            }
        }
    }
}