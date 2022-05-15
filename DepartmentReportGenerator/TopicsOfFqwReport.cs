using System.IO;
using System.Linq;
using DepartmentReportGenerator.DocEditor;
using DepartmentReportGenerator.Extensions;
using DepartmentReportGenerator.Model;

namespace DepartmentReportGenerator
{
    public class TopicsOfFqwReport
    {
        private readonly ITemplateFilesStorage _filesStorage;
            
        private IFile _file;

        public TopicsOfFqwReport(ITemplateFilesStorage filesStorage)
        {
            _filesStorage = filesStorage;
        }

        public void Generate(Fqw fqw)
        {
            using (_file = _filesStorage.TopicsOfFqwReport)
            {
                FillObjectInfo(fqw);
                FillInfoInTable(_file.Tables[0], fqw.Group);
            
                _file.SaveAs(
                    Path.Combine(Directory.GetCurrentDirectory(), "data",
                        $"TopicOfFqw_{fqw.Group.ShortName}_{fqw.DateOfCreation.ToString("yyyy_MM_dd_hh_mm_ss_FFF").Replace('.', '_')}"),
                    Extension.Default);
                
            }

            _file = null;
        }
        
        private void FillObjectInfo(object obj)
        {
            foreach (string fieldName in _file.Fields.Keys)
            {
                _file.Fields[fieldName].Text = FileFieldHelper.GetFieldValue(fieldName, obj);
            }
        }

        private void FillInfoInTable(ITable table, Group group)
        {
            if (table.CountRows < group.Students.Count)
            {
                table.AddRow(group.Students.Count - table.CountRows);
            }

            var tableFiller = new TableFiller(table);

            var counterForTable = new Counter(0);
            foreach (var (student, index) in group.Students.Select((item, index) => (item, index)))
            {
                counterForTable.Next();
                
                tableFiller.FillRowByIndex(index, counterForTable, group, student);
            }
        }
    }
}