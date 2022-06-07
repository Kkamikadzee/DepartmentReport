using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportController;
using ReportGenerator.Model;
using RepostWinForms.Utils;

namespace RepostWinForms
{
    // TODO: Помойный класс, надо будет отрефакторить, если останется время.
    public partial class ReportWinForm : Form, IReportView
    {
        private static readonly int MaxStatusLenght = Config.Instance.MaxStatusLenght;

        public event Action<Document, string, string> GenerateDocument;

        public ICollection<Department> Departments
        {
            get => department.Items as ICollection<Department>;
            set => department.DataSource = value;
        }
        public ICollection<Teacher> Teachers
        {
            get => practiceHeadmaster.Items as ICollection<Teacher>;
            set => practiceHeadmaster.DataSource = value;
        }

        public ICollection<string> FqwTemplateFiles
        {
            get => fqwTemplateFile.Items as ICollection<string>;
            set => fqwTemplateFile.DataSource = value;
        }
        public ICollection<string> PracticeTemplateFiles
        {
            get => practiceTemplateFile.Items as ICollection<string>;
            set => practiceTemplateFile.DataSource = value;
        }

        public ICollection<string> PracticeKind
        {
            get => practiceKind.Items as ICollection<string>;
            set => practiceKind.DataSource = value;
        }
        public ICollection<string> PracticeType
        {
            get => practiceType.Items as ICollection<string>;
            set => practiceType.DataSource = value;
        }

        public ReportWinForm()
        {
            InitializeComponent();
        }

        public void SetStatus(string status)
        {
            stripStatus.Text = status.Length < MaxStatusLenght 
                ? status
                : $"{status.Substring(0, MaxStatusLenght - 3)}...";
        }

        private void DepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            Department selectedDepartment = department.SelectedItem as Department;
            fqwGroup.DataSource = selectedDepartment.Groups;
            practiceGroup.DataSource = selectedDepartment.Groups;
        }

        private void FqwGenerate(object sender, EventArgs e)
        {
            var fqw = new Fqw()
            {
                Department = department.SelectedItem as Department,
                DateOfCreation = dateOfCreation.Value,
                Group = fqwGroup.SelectedItem as Group
            };

            var templateFile = fqwTemplateFile.SelectedItem as string;

            DocumentGenerate(fqw, templateFile);
        }

        private void PracticeGenerate(object sender, EventArgs e)
        {

            var practice = new Practice()
            {
                Department = department.SelectedItem as Department,
                DateOfCreation = dateOfCreation.Value,
                Group = practiceGroup.SelectedItem as Group,
                StartDate = practiceStartDate.Value,
                EndDate = practiceEndDate.Value,
                Headmaster = practiceHeadmaster.SelectedItem as Teacher,
                Kind = practiceKind.SelectedItem as string,
                Type = practiceType.SelectedItem as string,
                Base = practiceBase.Text
            };

            var templateFile = practiceTemplateFile.SelectedItem as string;

            DocumentGenerate(practice, templateFile);
        }

        private void DocumentGenerate(Document document, string templateFile)
        {
            var resultFilePath = ShowSaveFileDialog(document, templateFile);
            if (string.IsNullOrEmpty(resultFilePath))
            {
                SetStatus($"Генерация {templateFile} отчёта отменена");
            }

            GenerateDocument.Invoke(document, templateFile, resultFilePath);

            SetStatus($"Генерация {templateFile} отчёта...");
        }

        private string ShowSaveFileDialog(Document document, string templateName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "All files (*.*)|*.*";

            string defaultFileName = GetDefaultFileName(document, templateName);
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(defaultFileName);
            saveFileDialog.FileName = Path.GetFileName(defaultFileName);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        private string GetDefaultFileName(Document document, string templateName)
        {
            var dirPath = Path.Combine(Directory.GetCurrentDirectory(), Config.Instance.DefaultFolder);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            return Path.Combine(dirPath,
                $"{Path.GetFileNameWithoutExtension(templateName)}_{document.DateOfCreation:yyyy_MM_dd}_({DateTime.Now:yyyy_MM_dd_hh_mm_ss_FFF}).docx");

        }
    }
}
