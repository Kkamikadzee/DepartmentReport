using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Database.Utils;


namespace Database.Model
{
    public partial class Department : ReportGenerator.Model.Department
    {
        public Department()
        {
            Group = new HashSet<Group>();
        }

        public Guid Id { get; set; }
        public Guid HeadmasterId { get; set; }
        
        public Teacher HeadmasterRelation { get; set; }
        
        public virtual ICollection<Group> Group { get; set; }

        [NotMapped]
        public override IReadOnlyCollection<ReportGenerator.Model.Group> Groups
        {
            get => Group.ToArray();
            set => throw new NotImplementedException();
        }

        [NotMapped]
        public override ReportGenerator.Model.Teacher Headmaster
        {
            get => HeadmasterRelation;
            set => CopyModelToEntity.Copy(value, HeadmasterRelation);
        }
    }
}
