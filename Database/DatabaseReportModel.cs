using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReportController;
using ReportGenerator.Model;

namespace Database
{
    public class DatabaseReportModel : IReportModel
    {
        public ICollection<Department> Departments
        {
            get
            {
                using(var db = new DepartmentDbContext())
                {
                    return db.Department
                        .Include(d => d.Group)
                        .Include(d => d.HeadmasterRelation).ThenInclude(t => t.Person)
                        .OrderBy(d => d.Name)
                        .AsNoTracking()
                        .ToArray();
                }
            }
        }

        public ICollection<Teacher> Teachers
        {
            get
            {
                using(var db = new DepartmentDbContext())
                {
                    return db.Teacher
                        .Include(t => t.Person)
                        .OrderBy(t => t.Person.LastName)
                        .ThenBy(t => t.Person.FirstName)
                        .ThenBy(t => t.Person.Patronymic)
                        .AsNoTracking()
                        .ToArray();
                }
            }
        }
        
        public ICollection<Group> Groups
        {
            get
            {
                using(var db = new DepartmentDbContext())
                {
                    return db.Group
                        .AsNoTracking()
                        .OrderBy(g => g.ShortName)
                        .ToArray();
                }
            }
        }
        
        public ICollection<Student> Students
        {
            get
            {
                using(var db = new DepartmentDbContext())
                {
                    return db.Student
                        .Include(s => s.Person)
                        .Include(s => s.TeacherRelation)
                        .OrderBy(t => t.Person.LastName)
                        .ThenBy(t => t.Person.FirstName)
                        .ThenBy(t => t.Person.Patronymic)
                        .AsNoTracking()
                        .ToArray();
                }
            }
        }
    }
}
