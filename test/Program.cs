using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using DepartmentReportGenerator;
using DepartmentReportGenerator.DocEditor;
using DepartmentReportGenerator.Model;
using TemplateDocEditor;
using File = TemplateDocEditor.File;

namespace test
{
    internal class Program
    {
        public class TemplateFileStorage : ITemplateFilesStorage
        {
            private const string _pathToTemplateFile = @"data/TopicsOfFqwReport.template.dotx";
            
            public IFile TopicsOfFqwReport => new File(Path.Combine(Directory.GetCurrentDirectory(), _pathToTemplateFile));
        }

        public static void Main(string[] args)
        {
            var department = new Department()
            {
                Name = "Кафедра математического анализа и теории функций",
                Headmaster = new Person()
                {
                    FirstName = "Алексей",
                    LastName = "Клячин",
                    Patronymic = "Александрович"
                }
            };

            var group = new Group()
            {
                EducationType = "магистратуры",
                EducationalProgram = "Информационное обеспечение автоматизированных систем",
                SpecialityCode = "09.04.03",
                SpecialityName = "Прикладная информатика",
                Course = 3,
                ShortName =  "ПОМзм-191",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        FirstName = "Альбина",
                        LastName = "Бекингалиева",
                        Patronymic = "Жолдыхановна",
                        TopicOfFinalQualificationWork = "Разработка элективного курса «Приложения алгебры логики»",
                        Teacher = new Teacher()
                        {
                            FirstName = "Алексей",
                            LastName = "Клячин",
                            Patronymic = "Александрович",
                            ScienceDegree = "д.ф.-м. н.",
                            JobVacancy = "проф. каф. МАТФ"
                        }
                    },
                    new Student()
                    {
                        FirstName = "Ольга",
                        LastName = "Кузнецова",
                        Patronymic = "Александровна",
                        TopicOfFinalQualificationWork = "Разработка элективного курса «Основы web-конструирования»",
                        Teacher = new Teacher()
                        {
                            FirstName = "Алексей",
                            LastName = "Клячин",
                            Patronymic = "Александрович",
                            ScienceDegree = "д.ф.-м. н.",
                            JobVacancy = "проф. каф. МАТФ"
                        }
                    },
                    new Student()
                    {
                        FirstName = "Екатерина",
                        LastName = "Мосина",
                        Patronymic = "Владимировна",
                        TopicOfFinalQualificationWork = "Применение методов машинного обучения в сфере образования",
                        Teacher = new Teacher()
                        {
                            FirstName = "Гермашев",
                            LastName = "Илья",
                            Patronymic = "Васильевич",
                            ScienceDegree = "д.т.н.",
                            JobVacancy = "проф. каф. МАТФ"
                        }
                    }
                }
            };

            var report = new TopicsOfFqwReport(new TemplateFileStorage());
            
            report.Generate(department, group, DateTime.Now);

            // using (var df = new File(Path.Combine(Directory.GetCurrentDirectory(), "data", "template.dotx")))
            // {
            //     df.Fields["CurrentData"].Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            //     df.Fields["Department"].Text = "Какой-то не очень длинный текст";
            //     df.Fields["TextHeader"].Text = "Какой-то очень длинный текст текст текст текст текст текст текст текст " +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст" +
            //                                    "текст текст текст текст текст текст текст текст текст текст текст текст";
            //     
            //     df.Tables[0].AddRow();
            //     df.Tables[0].Cells[0, 0] = "Ячейка 0 0";
            //     df.Tables[0].Cells[0, 3] = "Ячейка 0 3";
            //
            //     df.Tables[0].AddRow();
            //     df.Tables[0].Cells[1, 2] = "Ячейка 1 2";
            //     df.Tables[0].Cells[1, 4] = "Ячейка 1 4";

            // df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Doc);
            // df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Default);
            // df.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "data", "result"), Extension.Pdf);
            // }
        }
    }
}