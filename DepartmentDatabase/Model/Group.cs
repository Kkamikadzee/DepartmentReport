using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReportGenerator.Model;

namespace Database.Model
{
    public partial class Group : ReportGenerator.Model.Group
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string EducationTypeString { get; set; }
        public string FormOfEducationString { get; set; }

        public virtual Department Department { get; set; }

        [NotMapped]
        public override DeclinableWord EducationType
        {
            get => new DeclinableWord(FormOfEducationString);
            set => value.ToString();
        }

        [NotMapped]
        public override DeclinableWord FormOfEducation
        {
            get => new DeclinableWord(FormOfEducationString);
            set => value.ToString();
        }

        [NotMapped]
        public override IReadOnlyCollection<ReportGenerator.Model.Student> Students
        {
            // TODO: В теории студентов можно кешировать.
            get
            {
                using(var db = new DepartmentDbContext())
                {
                    return db.GroupStudent
                        .Where(gs => gs.Group.Id == Id)
                        .Select(gs => gs.Student)
                        .Include(s => s.Person)
                        .ToArray();
                }
            }
            set => throw new NotImplementedException();
        }
    }
}
