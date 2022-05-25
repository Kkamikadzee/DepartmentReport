using System;
using ReportGenerator.TemplateEditor;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor.Utils
{
    public static class Convert
    {
        public static Word.WdSaveFormat ConvertDocExtensionToWdSaveFormat(Extension extension)
        {
            switch (extension)
            {
                case Extension.Default:
                    return Word.WdSaveFormat.wdFormatDocumentDefault;
                case Extension.Doc:
                    return Word.WdSaveFormat.wdFormatDocument;
                case Extension.Pdf:
                    return Word.WdSaveFormat.wdFormatPDF;
                default:
                    throw new ArgumentException($"Failed to convert '{extension}' extension to WdSaveFormat");
            }
        }
    }
}