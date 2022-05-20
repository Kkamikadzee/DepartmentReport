using System;
using System.Collections.Generic; 

namespace DepartmentDatabase.Model
{
    public partial class Department
    {
        public Department()
        {
            Group = new HashSet<Group>();
        }

        public Guid Id { get; set; }
        public Guid HeadmasterId { get; set; }
        public string Name { get; set; }

        public virtual Teacher Headmaster { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}
