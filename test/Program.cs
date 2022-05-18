using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using DepartmentReportGenerator;
using DepartmentReportGenerator.Extension;
using DepartmentReportGenerator.Generator;
using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;
using File = TemplateDocEditor.File;
using DepartmentDatabase;

namespace test
{
    internal class Program
    {
        public class WordTemplateFileStorage : TemplateFilesStorage
        {
            protected override IFile GetFileHelper(string relativeFilePath)
            {
                return new File(Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath));
            }
        }

        public static void Main(string[] args)
        {
            //Class1.Test();

            Fqw fqw = GetTestFqw();
            Practice practice = GetTestPractice();

            var fileStorage = new WordTemplateFileStorage();
            var reportCreator = new ReportCreator(fileStorage);
            foreach (var (templateName, document) in reportCreator.TemplateNames.Zip(new Document[] { fqw, fqw, practice, practice, practice }))
            {
                reportCreator.Create(document, templateName,
                Path.Combine(Directory.GetCurrentDirectory(), "reports",
                    $"{Path.GetFileNameWithoutExtension(templateName)}_{fqw.Group.ShortName}_{fqw.DateOfCreation:yyyy_MM_dd_hh_mm_ss_FFF}"),
                Extension.Default);
            }



            // var report = new SingleTableReportGenerator();
            //
            // using (var file = (new TemplateFileStorage()).TopicsOfFqwReport)
            // {
            //     report.Generate(file, fqw);
            //
            //     file.SaveAs(
            //         Path.Combine(Directory.GetCurrentDirectory(), "data",
            //             $"TopicOfFqw_{fqw.Group.ShortName}_{fqw.DateOfCreation:yyyy_MM_dd_hh_mm_ss_FFF}"),
            //         Extension.Default);
            // }
        }

        public static Department GetTestDepartment()
        {
            return new Department()
            {
                Name = "Кафедра математического анализа и теории функций",
                Headmaster = new Teacher()
                {
                    FirstName = "Алексей",
                    LastName = "Mr.Клячин",
                    Patronymic = "Александрович",
                    ScienceDegree = "д.ф.-м. н.",
                    JobVacancy = "проф. каф. МАТФ"
                }
            };
        }

        public static Group GetTestGroup()
        {
            return new Group()
            {
                EducationType = new DeclinableWord("магистратура"),
                EducationalProgram = "Информационное обеспечение автоматизированных систем",
                FormOfEducation = new DeclinableWord("очная"),
                SpecialityCode = "09.04.03",
                SpecialityName = "Прикладная информатика",
                Course = 3,
                ShortName = "ПОМзм-191",
                YearOfIssue = 2021,
                Students = new List<Student>()
                {
                    new Student()
                    {
                        FirstName = "Альбина",
                        LastName = "Бекингалиева",
                        Patronymic = "Жолдыхановна",
                        TopicOfFinalQualificationWork = "Разработка элективного курса «Приложения алгебры логики»",
                        BasisOfEducation = "бюджет",
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
                        BasisOfEducation = "бюджет",
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
                        BasisOfEducation = "бюджет",
                        Teacher = new Teacher()
                        {
                            FirstName = "Илья",
                            LastName = "Гермашев",
                            Patronymic = "Васильевич",
                            ScienceDegree = "д.т.н.",
                            JobVacancy = "проф. каф. МАТФ"
                        }
                    }
                }
            };
        }

        public static Fqw GetTestFqw()
        {
            return new Fqw()
            {
                Department = GetTestDepartment(),
                DateOfCreation = DateTime.Now,
                Group = GetTestGroup()
            };
        }

        public static Practice GetTestPractice()
        {
            return new Practice()
            {
                Department = GetTestDepartment(),
                DateOfCreation = DateTime.Now,
                Group = GetTestGroup(),
                Base = "Base практики",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Headmaster = GetTestGroup().Students.First().Teacher,
                Kind = "Kind практики",
                Type = "Type практики"
            };
        }
    }
}