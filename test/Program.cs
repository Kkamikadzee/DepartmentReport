using System;
using System.Collections.Generic;
using System.IO;
using DepartmentReportGenerator;
using DepartmentReportGenerator.DocEditor;
using DepartmentReportGenerator.Model;
using File = TemplateDocEditor.File;

namespace test
{
    internal class Program
    {
        public class TemplateFileStorage : ITemplateFilesStorage
        {
            private const string _pathToTemplateFile = @"data/TopicsOfFqwReport.template.dotx";

            public IFile TopicsOfFqwReport =>
                new File(Path.Combine(Directory.GetCurrentDirectory(), _pathToTemplateFile));
        }

        public static void Main(string[] args)
        {
            Fqw fqw = GetTestFqw();
            
            var report = new TopicsOfFqwReport(new TemplateFileStorage());

            report.Generate(fqw);
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