﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Cyriller;
using DepartmentReportGenerator;
using DepartmentReportGenerator.DocEditor;
using DepartmentReportGenerator.Model;
using TemplateDocEditor;
using Cyriller.Model;
using File = TemplateDocEditor.File;

namespace test
{
    internal class Program
    {
        public class TemplateFileStorage : ITemplateFilesStorage
        {
            private const string _pathToTemplateFile = @"data/Reviewers.template.dotx";
            
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
                EducationType = new DeclinableWord("магистратура"),
                EducationalProgram = "Информационное обеспечение автоматизированных систем",
                FormOfEducation = new DeclinableWord("очная"),
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

            // CyrNounCollection cnc = new CyrNounCollection();
            // CyrNoun noun = cnc.Get("магистратура", out CasesEnum @cases, out NumbersEnum @number);
            // Console.WriteLine(noun.Decline().Dative);
        }
    }
}