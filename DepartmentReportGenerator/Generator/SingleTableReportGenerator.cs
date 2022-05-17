using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;

namespace DepartmentReportGenerator.Generator
{
    public class SingleTableReportGenerator : ReportGenerator
    {
        protected override void FillOtherInfo(IFile file, Document document)
        {
            if (document is Fqw fqwDocument)
            {
                const int rowCounterStart = 1;
                FillInfoInTable(file.Tables[0], fqwDocument.Group.Students, rowCounterStart, fqwDocument);
                return;
            }

            if (document is Practice practiceDocument)
            {
                const int rowCounterStart = 1;
                FillInfoInTable(file.Tables[0], practiceDocument.Group.Students, rowCounterStart, practiceDocument);
                return;
            }
        }
    }
}