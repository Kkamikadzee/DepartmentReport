using System;
using Word = Microsoft.Office.Interop.Word;

namespace TemplateDocEditor
{
    public class DocFileUtils
    {
        public static Word.WdSaveFormat ConvertDocExtensionToWdSaveFormat(DocExtension extension)
        {
            switch (extension)
            {
                case DocExtension.Default:
                    return Word.WdSaveFormat.wdFormatDocumentDefault;
                    break;
                case DocExtension.Doc:
                    return Word.WdSaveFormat.wdFormatDocument;
                    break;
                case DocExtension.Pdf:
                    return Word.WdSaveFormat.wdFormatPDF;
                    break;
                default:
                    throw new ArgumentException($"Failed to convert '{extension}' extension to WdSaveFormat");
            }
        }
    }
}