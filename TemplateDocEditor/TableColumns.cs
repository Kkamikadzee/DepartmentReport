﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using ReportGenerator.TemplateEditor;

namespace TemplateDocEditor
{
    public class TableColumns: ITableColumns
    {
        // TODO: Перетащить в конфиг разбив на две части: "открывающаяся скобка (\[=\$)" и "закрывающаяся (\$=\])"
        public const string ColumnTagExpression = @"\[=\$.+\$=\]";
        private const int FrontOffsetTag = 3;
        private const int BackOffsetTag = 6;
        
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
                names[i] = tags[i]?.Substring(FrontOffsetTag, tags[i].Length - BackOffsetTag);
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

                tags[i] = tagMatch.Success ? tagMatch.Value : null;

                table.Cells[0, i] = null;
            }

            return tags;
        }
    }
}