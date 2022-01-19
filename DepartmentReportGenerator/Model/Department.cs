using System.Collections.Generic;

namespace DepartmentReportGenerator.Model
{
    public class Department
    {
        public string Name { get; set; }
        public People Headmaster { get; set; }
        public IReadOnlyList<Group> Groups { get; set; }
    }
}