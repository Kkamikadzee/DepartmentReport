using System;
using System.Collections.Generic;

namespace DepartmentDatabase.Model
{
    public partial class GroupStudent
    {
        public Guid GroupId { get; set; }
        public Guid StudentId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
