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
                        .ToArray();
                }
            }
        }
    }
}
