using System;

namespace ReportGenerator.Model
{
    public class Practice : Document
    {
        public Group Group { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Вид практики
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Тип практики
        /// </summary>
        public string Type { get; set; }
        public Teacher Headmaster { get; set; }
        public string Base { get; set; }
    }
}