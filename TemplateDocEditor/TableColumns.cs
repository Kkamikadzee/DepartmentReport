using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DepartmentReportGenerator.DocEditor;

namespace TemplateDocEditor
{
    public class TableColumns: ITableColumns
    {
        public const string ColumnTagExpression = @"\[TabCol\$.+\$TabCol\]";
        private const int FrontOffsetTag = 8;
        private const int BackOffsetTag = 16;
        
        private readonly IReadOnlyList<string> _columnTags;
        private readonly IReadOnlyList<string> _columnNames;
        
        public IReadOnlyList<string> ColumnNames => _columnNames;
        
        public TableColumns(Table docTable)
        {
            _columnTags = GetAllHeaderTags(docTable);
            _columnNames = GetColumnNamesByTags(_columnTags);
        }
        
        private IReadOnlyList<string> GetColumnNamesByTags(IReadOnlyList<string> tags)
        {
            var names = new string[tags.Count];

            for(var i = 0; i < tags.Count; i++)
            {
                names[i] = tags[i].Substring(FrontOffsetTag, tags[i].Length - BackOffsetTag);
            }

            return names;
        }
        
        /// <summary>
        /// Получает из нулевой строки теги для заголовка.
        /// </summary>
        /// <returns>Список заголовков</returns>
        private IReadOnlyList<string> GetAllHeaderTags(Table table)
        {
            var tags = new string[table.CountColumns];
            for (var i = 0; i < table.CountColumns; i++)
            {
                var tmp = table.Cells[0, i];
                var tagMatch = Regex.Match(table.Cells[0, i], ColumnTagExpression);
                if (!tagMatch.Success)
                {
                    throw new Exception($"Not found tag in cell [0, {i}].");
                }

                tags[i] = tagMatch.Value;

                table.Cells[0, i] = null;
            }

            return tags;
        }
    }
}