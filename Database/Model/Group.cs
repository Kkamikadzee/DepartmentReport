using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReportGenerator.Model;
using ReportGenerator.Utils;

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
            get => DeclinableWordCreator.Instance.Create(EducationTypeString);
            set => value.ToString();
        }

        [NotMapped]
        public override DeclinableWord FormOfEducation
        {
            get => DeclinableWordCreator.Instance.Create(FormOfEducationString);
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
                        .Include(gs => gs.Student).ThenInclude(s => s.Person)
                        .Include(gs => gs.Student).ThenInclude(s => s.TeacherRelation).ThenInclude(t => t.Person)
                        .Where(gs => gs.Group.Id == Id)
                        .Select(gs => gs.Student)
                        .OrderBy(t => t.Person.LastName)
                        .ThenBy(t => t.Person.FirstName)
                        .ThenBy(t => t.Person.Patronymic)
                        .AsNoTracking()
                        .ToArray();
                }
            }
            set => throw new NotImplementedException();
        }
    }
}
