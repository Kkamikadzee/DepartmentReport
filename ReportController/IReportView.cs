using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportController
{
    public interface IReportView
    {
        event Action<Document, string, string> GenerateDocument;

        ICollection<Department> Departments { get; set; }
        ICollection<Teacher> Teachers { get; set; }

        ICollection<string> FqwTemplateFiles { get; set; }
        ICollection<string> PracticeTemplateFiles { get; set; }

        ICollection<string> PracticeKind { get; set; }
        ICollection<string> PracticeType { get; set; }

        void SetStatus(string status);
    }
}
