using System;
using System.Collections.Generic;
using System.Linq;
using DepartmentReportGenerator.DocEditor;

namespace DepartmentReportGenerator
{
    public class TableFiller
    {
        private ITable _table;

        public TableFiller(ITable table)
        {
            _table = table;
        }

        public void FillRowByIndex(int rowIndex, params object[] objs)
        {
            if (_table.CountColumns < rowIndex)
            {
                return;
            }
            
            foreach (var (columnName, index) in _table.ColumnNames.Select((item, index) => (item, index)))
            {
                if (string.IsNullOrEmpty(columnName))
                {
                    _table.Cells[rowIndex, index] = string.Empty;
                    continue;
                }

                _table.Cells[rowIndex, index] = IsFormatColumn(columnName)
                    ? GetFormatColumnValue(columnName, objs)
                    : GetColumnValue(columnName, objs);
            }
        }

        private bool IsFormatColumn(string columnName)
        {
            return columnName[0] == '"';
        }

        private string GetColumnValue(string columnName, object[] objs)
        {
            object cellValueObj =
                objs.FirstOrDefault(o => Utils.FileFieldNameStartsWithTypeName(columnName, o.GetType()));

            return cellValueObj is null ? string.Empty : Utils.GetPropertyValueByFormatString(cellValueObj, columnName);
        }

        private string GetFormatColumnValue(string columnName, object[] objs)
        {
            string[] splitColumnName = columnName.Split('$');
            string format = splitColumnName[0].Trim('"');
            var formatValues = new string[splitColumnName.Length - 1];
            for (var i = 1; i < splitColumnName.Length; ++i)
            {
                formatValues[i - 1] = GetColumnValue(splitColumnName[i], objs);
            }

            string result = string.Empty;
            try
            {
                result = string.Format(format, formatValues);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}