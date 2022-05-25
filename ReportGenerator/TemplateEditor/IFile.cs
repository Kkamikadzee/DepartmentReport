using System;
using System.Collections.Generic;

namespace ReportGenerator.TemplateEditor
{
    public interface IFile: IDisposable
    {
        IReadOnlyDictionary<string, IField> Fields { get; }
        IReadOnlyList<ITable> Tables { get; }
        
        void SaveAs(string absolutePathFile, Extension extension);
    }
}