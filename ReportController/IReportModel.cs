using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportController
{
    public interface IReportModel
    {
        ICollection<Department> Departments { get; }
        ICollection<Teacher> Teachers { get; }
        ICollection<Group> Groups { get; }
        ICollection<Student> Students { get; }
        
    }
}
