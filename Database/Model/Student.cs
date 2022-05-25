using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Utils;

namespace Database.Model
{
    public partial class Student : ReportGenerator.Model.Student
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid TeacherId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Teacher TeacherRelation { get; set; }

        [NotMapped]
        public override ReportGenerator.Model.Teacher Teacher
        {
            get => TeacherRelation;
            set => CopyModelToEntity.Copy(value, TeacherRelation);
        }

        [NotMapped]
        public override string FirstName
        {
            get => Person.FirstName;
            set => Person.FirstName = value;
        }

        [NotMapped]
        public override string LastName
        {
            get => Person.LastName;
            set => Person.LastName = value;
        }

        [NotMapped]
        public override string Patronymic
        {
            get => Person.Patronymic;
            set => Person.Patronymic = value;
        }
    }
}