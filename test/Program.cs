using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using DepartmentReportGenerator;
using DepartmentReportGenerator.Generator;
using DepartmentReportGenerator.Model;
using DepartmentReportGenerator.TemplateEditor;
using File = TemplateDocEditor.File;

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
            // var cfg = ConfigurationManager.GetSection("ReportGeneratorSettings") as NameValueCollection;
            // var str = cfg?.Get("Key0");
            // Console.WriteLine("The value of Key0: " + str);


            Fqw fqw = GetTestFqw();

            var fileStorage = new WordTemplateFileStorage();
            var reportCreator = new ReportCreator(fileStorage);
            reportCreator.Create(fqw, reportCreator.TemplateNames.First(),
                Path.Combine(Directory.GetCurrentDirectory(), "data",
                    $"{reportCreator.TemplateNames.First()}_{fqw.Group.ShortName}_{fqw.DateOfCreation:yyyy_MM_dd_hh_mm_ss_FFF}"),
                Extension.Default);


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

        public static Fqw GetTestFqw()
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

            var fqw = new Fqw()
            {
                Department = department,
                DateOfCreation = DateTime.Now,
                Group = group
            };

            return fqw;
        }
    }
}