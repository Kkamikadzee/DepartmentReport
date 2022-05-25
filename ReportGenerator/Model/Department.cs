using System.Collections.Generic;

namespace ReportGenerator.Model
{
    public class Department
    {
        public virtual string Name { get; set; }
        public virtual Teacher Headmaster { get; set; }
        public virtual IReadOnlyCollection<Group> Groups { get; set; }
    }
}