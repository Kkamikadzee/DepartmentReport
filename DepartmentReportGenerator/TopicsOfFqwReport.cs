using System;
using System.Collections;
using System.Collections.Generic;
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

        public void Generate(Department department, Group group, DateTime date)
        {
            using (_file = _filesStorage.TopicsOfFqwReport)
            {
                FillObjectInfo(department);
                FillObjectInfo(group);
                FillDateField(date);
                FillInfoInTable(_file.Tables[0], group);
            
                _file.SaveAs(
                    Path.Combine(Directory.GetCurrentDirectory(), "data",
                        $"TopicOfFqw_{group.ShortName}_{date.ToString(DateFormatter.TopicOfFqw).Replace('.', '_')}"),
                    Extension.Default);
                
            }

            _file = null;
        }

        private void FillFileField(string fieldKey, string fieldValue)
        {
            if (_file.Fields.ContainsKey(fieldKey))
            {
                _file.Fields[fieldKey].Text = fieldValue;
            }
        }

        private void FillFileFields(IEnumerable<string> fieldKeys, IEnumerable<string> fieldValues)
        {
            foreach (var (key, value) in fieldKeys.Zip(fieldValues))
            {
                FillFileField(key, value);
            }
        }
        
        private void FillObjectInfo(object obj)
        {
            Type departmentType = obj.GetType();
            IEnumerable<string> fieldsKey = _file.Fields.Keys.Where(k => Utils.FileFieldNameStartsWithTypeName(k, departmentType));
            IEnumerable<string> fieldsValue =
                fieldsKey.Select(k => Utils.GetPropertyValueByFormatString(obj, k));
            FillFileFields(fieldsKey, fieldsValue);
        }

        private void FillDateField(DateTime date)
        {
            IEnumerable<string> fieldsKey = _file.Fields.Keys.Where(k => k.Equals("CurrentDate"));
            IEnumerable<string> fieldsValue =
                fieldsKey.Select(k => date.ToString(DateFormatter.TopicOfFqw));
            FillFileFields(fieldsKey, fieldsValue);
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