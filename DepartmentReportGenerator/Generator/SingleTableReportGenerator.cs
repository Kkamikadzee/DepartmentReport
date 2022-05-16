using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;

namespace DepartmentReportGenerator.Generator
{
    public class SingleTableReportGenerator : ReportGenerator
    {
        protected override void FillOtherInfo(IFile file, Document document)
        {
            if (document is Fqw castedDocument)
            {
                const int rowCounterStart = 1;
                FillInfoInTable(file.Tables[0], castedDocument.Group.Students, rowCounterStart, castedDocument.Group);
            }
        }
    }
}